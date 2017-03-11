Imports System.Net.Sockets
Imports System.Text.Encoding
Imports System.Threading
Imports De.JanRoslan.NETUtils.Collections

Module Module1

    Sub Main()

        Dim client As New TcpClient("localhost", 2848)

        ' Simulate large data
        'While True

        Dim msg As Byte() = ArrayUtils.Concat(UTF8.GetBytes("test"), New Byte() {&H17, &H17}, UTF8.GetBytes("lol"))

        client.GetStream().Write(msg, 0, msg.Length)
        For Each b As Byte In msg
            Console.WriteLine(b)
        Next
        'End While

        Thread.Sleep(10000)
    End Sub



End Module
