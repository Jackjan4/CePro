Imports De.JanRoslan.CePro.Core.Net
Imports De.JanRoslan.CePro.Net

Namespace Moduling

    Public Interface BaseModule

        Sub Init()


        Sub Process(msg As IClientMessage)
    End Interface


End Namespace