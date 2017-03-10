Imports System.IO
Imports System.Net
Imports System.Text.Encoding

Namespace Net

    Public Class ClientRequest
        Implements IClientMessage

        Private Property Processing As List(Of Byte())

        Public ReadOnly Property Answer As MemoryStream Implements IClientMessage.Answer

        Public ReadOnly Property RemoteIp As IPAddress Implements IClientMessage.RemoteIp

        Public ReadOnly Property Port As Integer Implements IClientMessage.Port

        Public ReadOnly Property Message As Byte() Implements IClientMessage.Message

        Public ReadOnly Property MessageString As String Implements IClientMessage.MessageString

        Sub New(msg As Byte(), remoteIp As IPAddress, port As Integer)
            Me.Message = msg
            Me.RemoteIp = remoteIp
            Me.Port = port
            MessageString = UTF8.GetString(msg)

            Me.Answer = New MemoryStream()

        End Sub


        Public Sub WriteAnswer(msg() As Byte) Implements IClientMessage.WriteAnswer

        End Sub


        Public Sub AddProcessing(msg() As Byte) Implements IClientMessage.AddProcessing
            Processing.Add(msg)
        End Sub


        Public Function GetMessageHeader() As Byte() Implements IClientMessage.GetMessageHeader
            For i As Integer = 0 To 7

            Next
        End Function


        Public Function GetMessageContent() As Byte() Implements IClientMessage.GetMessageContent

        End Function
    End Class

End Namespace
