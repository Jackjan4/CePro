Imports System.Collections.Concurrent
Imports System.Net.Sockets
Imports System.Threading

Namespace Net

    ' TODO: Enhance performance by running multi-threaded not only one new thread
    Public Class ConnectionWatchdog

        Private thread As Thread
        Private Property Running As Boolean

        Private Property WatchedClients As ConcurrentQueue(Of TcpClient)

        Private ReadOnly Property RemovedClients As ConcurrentQueue(Of TcpClient)

        Sub New()

            thread = New Thread(AddressOf Run)
            WatchedClients = New ConcurrentQueue(Of TcpClient)
            RemovedClients = New ConcurrentQueue(Of TcpClient)

        End Sub

        Public Sub Start()
            Running = True
            thread.Start()

        End Sub


        Public Function GetRemovedClient() As Tuple(Of Boolean, TcpClient)
            Dim result As TcpClient = Nothing

            Dim boolRes As Boolean = RemovedClients.TryDequeue(result)

            Return New Tuple(Of Boolean, TcpClient)(boolRes, result)
        End Function


        Public Sub AddClient(client As TcpClient)

            WatchedClients.Enqueue(client)

        End Sub



        Private Sub Run()

            While Running

                Dim client As TcpClient = Nothing
                WatchedClients.TryPeek(client)

                If (client IsNot Nothing) Then

                    ' Check synchronously if client is connected
                    If (Not client.Connected) Then

                        WatchedClients.TryDequeue(client)
                        If (client IsNot Nothing) Then
                            RemovedClients.Enqueue(client)
                        End If

                    End If
                End If
            End While
        End Sub
    End Class


End Namespace