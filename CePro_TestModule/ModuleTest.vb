Imports System.Text
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net

<ModuleInfo("Testing module", "TestModule", "A module for testing", 0, False, "Jan Roslan", "TestVersion", Nothing, {"test", "rsa"}, {"test", "testcmd"})>
Public Class ModuleTest
    Implements IBaseModule

    Private count As Integer = 0

    Sub New()

    End Sub

    Public Sub Init() Implements IBaseModule.Init

    End Sub

    Public Sub Process(msg As IClientMessage) Implements IBaseModule.Process
        msg.WriteAnswer(Encoding.UTF8.GetBytes("Hallo"))
        count = count + 1
    End Sub
End Class
