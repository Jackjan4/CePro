
Imports System.Net.Sockets


''' <summary>
''' Accepts a socket a handles the reading/writing to it
''' Passes the message to the after reading to the ModuleManager
''' </summary>
Public Class MessageProcessor

    Private Property socket As Socket

    Sub New(socket As Socket)
        Me.socket = socket

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="threadContext"></param>
    Sub Run(threadContext As Object)

        While (socket.Available > 0)

        End While

    End Sub
End Class
