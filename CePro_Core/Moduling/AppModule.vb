Imports De.JanRoslan.CePro.Core.Net

Namespace Moduling

    Public Class AppModule

        Public ReadOnly Property Name As String
        Public ReadOnly Property Description As String
        Public ReadOnly Property Version As Integer
        Public ReadOnly Property Author As String
        Public ReadOnly Property VersionName As String
        Public ReadOnly Property ListenedReqs As String()
        Public ReadOnly Property ListenedCmds As String()
        Public ReadOnly Property Dependency As String
        Public ReadOnly Property First As Boolean

        Public ReadOnly Property BaseModule As IBaseModule

        Sub New(modu As IBaseModule)

            Me.BaseModule = modu

            Dim modInfo As ModuleInfo = BaseModule.GetType.GetCustomAttributes(GetType(ModuleInfo), False).FirstOrDefault()

            Me.Name = modInfo.Name
            Me.Description = modInfo.Description
            Me.Version = modInfo.Version
            Me.Author = modInfo.Author
            Me.VersionName = modInfo.Name
            Me.ListenedReqs = modInfo.ListenedReqs
            Me.ListenedCmds = modInfo.ListenedCmds
            Me.Dependency = modInfo.Dependency
            Me.First = modInfo.First

        End Sub


        Sub Init()
            Me.BaseModule.Init()
        End Sub

        Sub Process(message As ClientRequest)
            Me.BaseModule.Process(message)
        End Sub

    End Class


End Namespace