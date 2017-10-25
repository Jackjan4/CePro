Imports System.Text
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net

<ModuleInfo("Testing module", "TestModule2", "A module for testing", 0, False, False, "Jan Roslan", "TestVersion", Nothing, {"test", "rsa"}, {"test", "testcmd"})>
Public Class ModuleTest2
    Implements IBaseModule

    Private count As Integer = 0

    Sub New()

    End Sub

    Public Sub Init() Implements IBaseModule.Init

    End Sub

    Public Sub Process(msg As IClientMessage) Implements IBaseModule.Process
        msg.WriteAnswer(Encoding.UTF8.GetBytes("Hallo2"))
        msg.AddProcessing(Encoding.UTF8.GetBytes("Hallo2"))
        count = count + 1
    End Sub

    Public Sub ProcessBackwards(msg As IClientMessage) Implements IBaseModule.ProcessBackwards

    End Sub
End Class
