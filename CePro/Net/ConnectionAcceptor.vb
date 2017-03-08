Imports System.Collections.Concurrent
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Namespace Net

    Public Class ConnectionManager

        Private thread As Thread

        Private Listener As TcpListener
        Private ReadOnly Port As Integer
        Public Property Running As Boolean

        Private activeClients As ConcurrentBag(Of TcpClient)



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="port"></param>
        Sub New(port As Integer)
            activeClients = New ConcurrentBag(Of TcpClient)

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


            While Running

                Dim client As TcpClient = Listener.AcceptTcpClient

                Socket.Select()





            End While
        End Sub

    End Class


End Namespace