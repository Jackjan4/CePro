
Imports System.Net
Imports System.Net.Sockets
Imports De.JanRoslan.CePro.Moduling
Imports De.JanRoslan.CePro.Net

''' <summary>
''' Accepts a socket a handles the reading/writing to it
''' Passes the message to the after reading to the ModuleManager
''' </summary>
Public Class MessageProcessor

    Private Property Socket As Socket

    Sub New(socket As Socket)
        Me.socket = socket

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="threadContext"></param>
    Sub Run(threadContext As Object)

        If (socket.Available > 0) Then

            Dim buffer(socket.Available) As Byte

            Try
                socket.Receive(buffer)


                Dim ipEnd As IPEndPoint = DirectCast(socket.RemoteEndPoint, IPEndPoint)
                Dim cReq As New ClientRequest(buffer, ipEnd.Address, ipEnd.Port)

                ModuleManager.Instance.ProcessInModules(cReq)

                socket.Send(cReq.Answer.ToArray())

            Catch

            End Try



        End If

    End Sub
End Class
