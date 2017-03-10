Imports System.Collections.Concurrent
Imports System.Net
Imports System.Collections
Imports System.Net.Sockets
Imports System.Threading
Imports De.JanRoslan.CePro.My
Imports De.JanRoslan.CePro.Core.My

Namespace Net

    Public Class ConnectionManager

        Private thread As Thread

        Private Listener As TcpListener
        Private ReadOnly Port As Integer
        Public Property Running As Boolean

        Private activeClients As List(Of TcpClient)



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="port"></param>
        Sub New(port As Integer)
            activeClients = New List(Of TcpClient)
            Me.Port = port
            thread = New Thread(AddressOf Run)
        End Sub

        Sub New()
            Me.New(MySettings.Default.DefaultPort)
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        Sub InitAndStart()

            Listener = New TcpListener(IPAddress.Any, Port)
            Running = True
            Listener.Start()

            thread.Start()

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Private Sub Run()

            Dim readList As New List(Of Socket)
            Dim errorList As New List(Of Socket)
            Dim writeList As New List(Of Socket)

            Dim pending As Boolean = False
            Dim pendingClient As TcpClient = Nothing

            While Running

                If (pendingClient IsNot Nothing) Then
                    activeClients.Add(pendingClient)
                    pendingClient = Nothing
                End If

                If (Not pending) Then
                    pending = True

                    ' 
                    Listener.BeginAcceptTcpClient(New AsyncCallback(Sub(res)
                                                                        pendingClient = Listener.EndAcceptTcpClient(res)
                                                                        pending = False
                                                                    End Sub), Nothing)
                End If



                For Each client As TcpClient In activeClients
                    readList.Add(client.Client)
                    errorList.Add(client.Client)
                    writeList.Add(client.Client)
                Next


                If (readList.Count <> 0 OrElse errorList.Count <> 0 OrElse writeList.Count <> 0) Then
                    Socket.Select(readList, writeList, errorList, -1)
                End If

                ' Action on Readable sockets
                For Each sock As Socket In readList
                    Dim msgProc As New MessageProcessor(sock)
                    ThreadPool.QueueUserWorkItem(AddressOf msgProc.Run)
                Next

                ' Actions on error sockets
                For Each sock As Socket In errorList


                Next


            End While
        End Sub






    End Class


End Namespace