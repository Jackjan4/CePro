Imports De.JanRoslan.CePro.Net

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

        Public ReadOnly Property BaseModule As BaseModule

            Sub  New(baseM as BaseModule)
            Me.baseModule = baseM
        End Sub


        Sub Init()
            Me.BaseModule.Init()
        End Sub

        Sub Process(message As ClientRequest)
            Me.BaseModule.Process(message)
        End Sub

    End Class


End Namespace