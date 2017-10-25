Imports De.JanRoslan.CePro.Core.Net

Namespace Moduling

    Public Interface IBaseModule

        Sub Init()


        Sub Process(msg As IClientMessage)



        ''' <summary>
        ''' Processes a user request. During this method call the request is already running backwards through the module pipe back to the user
        ''' </summary>
        ''' <param name="msg"></param>
        Sub ProcessBackwards(msg As IClientMessage)

    End Interface


End Namespace