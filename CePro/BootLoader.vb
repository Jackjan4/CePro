
Imports De.JanRoslan.CePro.Core.Logging
Imports De.JanRoslan.CePro.Core.Moduling
Imports De.JanRoslan.CePro.Core.Net
Imports De.JanRoslan.NETUtils.Logging

Public Class BootLoader

    Sub New()

    End Sub

    Sub Run()

        ' Init ModuleManager
        Dim d As ModuleManager = ModuleManager.Instance
        Core.Logging.Logger.Instance.Log("ModuleManager was succesfully initialized", LogLevel.INFO, "Bootloader")

        ' Init ConnectionManager
        Dim conMan As New ConnectionManager()
        conMan.InitAndStart()
        Core.Logging.Logger.Instance.Log("ConnectionManager was sucesfully initialized and started", LogLevel.INFO, "Bootloader")

    End Sub
End Class
