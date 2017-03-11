
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net

Public Class BootLoader

    Sub New()

    End Sub

    Sub Run()

        ' Init ModuleManager
        Dim d As ModuleManager = ModuleManager.Instance
        Console.WriteLine("Succesfully loaded ModuleManager")

        ' Init ConnectionManager
        Dim conMan As New ConnectionManager()
        conMan.InitAndStart()

    End Sub
End Class
