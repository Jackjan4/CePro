Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports De.JanRoslan.CePro.Core.Logging
Imports De.JanRoslan.CePro.Core.My
Imports De.JanRoslan.NETUtils.Logging

Namespace Net

    Public Class ConnectionManager

        Private thread As Thread

        Private Listener As TcpListener
        Private ReadOnly Port As Integer
        Public Property Running As Boolean

        Private Property Watchdog As ConnectionWatchdog

        ' TODO: Change this to Dictionary?
        Private activeClients As List(Of TcpClient)



        ''' <summary>
        ''' Creates this ConnectionManager with the given port
        ''' </summary>
        ''' <param name="port"></param>
        Sub New(port As Integer)
            activeClients = New List(Of TcpClient)
            Me.Port = port
            thread = New Thread(AddressOf Run)
        End Sub


        ''' <summary>
        ''' Creates this ConnectionManager with the given default port
        ''' </summary>
        Sub New()
            Me.New(MySettings.Default.DefaultPort)
            Watchdog = New ConnectionWatchdog
        End Sub



        ''' <summary>
        ''' Initializes and starts this ConnectionManager
        ''' </summary>
        Sub InitAndStart()

            Listener = New TcpListener(IPAddress.Any, Port)
            Running = True

            Watchdog.Start()

            Listener.Start()
            thread.Start()

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Private Sub Run()

            Logging.Logger.Instance.Log("Listening for clients on port " & Port & " ...", LogLevel.INFO, "ConnectionManager")

            Dim readList As New List(Of Socket)
            Dim errorList As New List(Of Socket)
            Dim writeList As New List(Of Socket)

            Dim pending As Boolean = False
            Dim pendingClient As TcpClient = Nothing

            ' Connection main loop
            While Running

                ' Add pendingClient to activeClients
                If (pendingClient IsNot Nothing) Then
                    activeClients.Add(pendingClient)

                    Dim clientAddress As IPEndPoint = DirectCast(pendingClient.Client.RemoteEndPoint, IPEndPoint)
                    Logging.Logger.Instance.Log("Accepted client: " & clientAddress.ToString() & " ; Active clients: " & activeClients.Count, LogLevel.INFO, "ConnectionManager")

                    pendingClient = Nothing
                End If

                ' Accept TcpClients if not already accepting one
                If (Not pending) Then
                    pending = True
                    Listener.BeginAcceptTcpClient(New AsyncCallback(Sub(res)
                                                                        pendingClient = Listener.EndAcceptTcpClient(res)
                                                                        Watchdog.AddClient(pendingClient)
                                                                        pending = False
                                                                    End Sub), Nothing)
                End If


                ' Process activeCLients in Connection selector
                For Each client As TcpClient In activeClients
                    readList.Add(client.Client)
                    errorList.Add(client.Client)
                    writeList.Add(client.Client)
                Next
                If (readList.Count <> 0 OrElse errorList.Count <> 0 OrElse writeList.Count <> 0) Then
                    Socket.Select(readList, writeList, errorList, -1)
                End If


                ' Action on Readable sockets -> Process them in MessageProcessor
                For Each sock As Socket In readList
                    Dim msgProc As New RequestProcessor(sock)
                    ThreadPool.QueueUserWorkItem(AddressOf msgProc.Run)
                Next

                ' Actions on error sockets -> Disconnect them
                For Each sock As Socket In errorList

                    sock.Close()
                    Dim client As TcpClient = GetClientBySocket(sock)
                    client.Close()
                    activeClients.Remove(client)
                Next

                For Each sock As Socket In writeList

                Next


                ' Remove clients that are not connected anymore
                Dim clientTuple As Tuple(Of Boolean, TcpClient) = Nothing
                Do
                    clientTuple = Watchdog.GetRemovedClient()
                    If (clientTuple.Item1 = True) Then
                        activeClients.Remove(clientTuple.Item2)
                        Logging.Logger.Instance.Log("Removed client " & DirectCast(clientTuple.Item2.Client.RemoteEndPoint, IPEndPoint).ToString(), LogLevel.INFO, "ConnectionManager")
                    End If
                Loop While clientTuple.Item1 = True

            End While
        End Sub



        ''' <summary>
        ''' Returns the TcpCLient from activeClients which contains the given socket
        ''' </summary>
        ''' <param name="socket"></param>
        ''' <returns></returns>
        Private Function GetClientBySocket(socket As Socket) As TcpClient
            Dim result As TcpClient = Nothing

            For Each client As TcpClient In activeClients
                If (client.Client.Equals(socket)) Then
                    result = client
                    Exit For
                End If
            Next

            Return result
        End Function

    End Class


End Namespace