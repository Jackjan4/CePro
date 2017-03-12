
Imports System.Net
Imports System.Net.Sockets
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net

''' <summary>
''' Accepts a socket a handles the reading/writing to it
''' Passes the message to the after reading to the ModuleManager
''' </summary>
Public Class RequestProcessor

    Private Property Socket As Socket

    Sub New(socket As Socket)
        Me.Socket = socket

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="threadContext"></param>
    Sub Run(threadContext As Object)

        If (Socket.Available > 0) Then

            Dim buffer(Socket.Available) As Byte

            Try
                Socket.Receive(buffer)

                ' TODO Send everything to ReqManager to process splitted requests

                Dim ipEnd As IPEndPoint = DirectCast(Socket.RemoteEndPoint, IPEndPoint)
                Dim cReq As New ClientRequest(buffer, ipEnd.Address, ipEnd.Port)

                ModuleManager.Instance.ProcessInModules(cReq)

                Socket.Send(cReq.Answer.ToArray())

            Catch

            End Try



        End If

    End Sub
End Class
