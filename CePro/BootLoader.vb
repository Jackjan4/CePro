
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net
Imports De.JanRoslan.CePro.Moduling
Imports De.JanRoslan.CePro.Net

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
