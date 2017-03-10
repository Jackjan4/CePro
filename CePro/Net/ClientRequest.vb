Imports System.IO
Imports System.Net

Namespace Net

    Public Class ClientRequest
        Implements IClientMessage

        Private Property Processing As List(Of Byte())

        Public ReadOnly Property Answer As MemoryStream Implements IClientMessage.Answer

        Public ReadOnly Property RemoteIp As IPAddress Implements IClientMessage.RemoteIp

        Public ReadOnly Property Port As Integer Implements IClientMessage.Port

        Public ReadOnly Property Message As Byte() Implements IClientMessage.Message


        Sub New(msg As Byte(), remoteIp As IPAddress, port As Integer)
            Me.Message = msg
            Me.RemoteIp = remoteIp
            Me.Port = port

            Me.Answer = New MemoryStream()

        End Sub


        Public Sub WriteAnswer(msg() As Byte) Implements IClientMessage.WriteAnswer

        End Sub


        Public Sub AddProcessing(msg() As Byte) Implements IClientMessage.AddProcessing
            Processing.Add(msg)
        End Sub


        Public Function GetMessageHeader() As Byte() Implements IClientMessage.GetMessageHeader

        End Function


        Public Function GetMessageContent() As Byte() Implements IClientMessage.GetMessageContent

        End Function
    End Class

End Namespace
