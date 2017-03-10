Imports System.IO
Imports System.Net

Namespace Net

    Public Interface IClientMessage

        ReadOnly Property RemoteIp As IPAddress
        ReadOnly Property Port As Integer
        ReadOnly Property Message As Byte()
        ReadOnly Property MessageString As String
        ReadOnly Property Answer As MemoryStream

        Sub WriteAnswer(msg As Byte())
        Sub AddProcessing(msg As Byte())

        Function GetMessageHeader() As Byte()

        Function GetMessageContent() As Byte()

    End Interface

End Namespace