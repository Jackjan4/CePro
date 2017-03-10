Imports System.Text
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net

<ModuleInfo("TestModule", "A module for testing", 0, False, "Jan Roslan", "Test", Nothing, {"test", "rsa"}, {"test", "testcmd"})>
Public Class ModuleTest
    Implements BaseModule

    Private count As Integer = 0

    Sub New()

    End Sub

    Public Sub Init() Implements BaseModule.Init

    End Sub

    Public Sub Process(msg As IClientMessage) Implements BaseModule.Process
        msg.WriteAnswer(Encoding.UTF8.GetBytes("Hallo"))
        Console.WriteLine("Ja hallo " & count)
        count = count + 1
    End Sub
End Class
