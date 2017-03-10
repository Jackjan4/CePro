Imports System.Net.Sockets
Imports System.Text.Encoding
Imports System.Threading

Module Module1

    Sub Main()

        Dim client As New TcpClient("localhost", 2848)

        ' Simulate large data
        'While True

        Dim header As String = "test"
        Dim escape As Byte = &H17
        Dim content As String = "lol"


        Dim message(header.Length + 2 + content.Length) As Byte


        UTF8.GetBytes(header).CopyTo(message, 0)
        UTF8.GetBytes(escape).CopyTo(z, x.Length);







        client.GetStream().Write(UTF8.GetBytes("testlolol"), 0, 9)
        For Each b As Byte In UTF8.GetBytes("testlol")
            Console.WriteLine(b)
        Next
        'End While

        Thread.Sleep(10000)
    End Sub



End Module
