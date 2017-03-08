Imports System.Collections.Concurrent
Imports System.Net
Imports System.Collections
Imports System.Net.Sockets
Imports System.Threading

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

            thread = New Thread(AddressOf Run)
        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Sub Init()

            Listener = New TcpListener(IPAddress.Any, Port)
            Running = True
            Listener.Start()

            thread.Start()

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Sub Run()

            Dim readList As New List(Of Socket)
            Dim errorList As New List(Of Socket)
            Dim pending As Boolean = False

            While Running

                If (Not pending) Then
                    pending = True

                    ' 
                    Listener.BeginAcceptTcpClient(New AsyncCallback(Sub(res)
                                                                        activeClients.Add(Listener.EndAcceptTcpClient(res))
                                                                        pending = False
                                                                    End Sub), Nothing)
                End If



                For Each client As TcpClient In activeClients
                    readList.Add(client.Client)
                    errorList.Add(client.Client)
                Next



                Socket.Select(readList, Nothing, errorList, -1)


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