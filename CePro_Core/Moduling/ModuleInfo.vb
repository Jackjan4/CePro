Namespace Moduling

    <AttributeUsage(AttributeTargets.Class)>
    Public Class ModuleInfo
        Inherits Attribute

        Public ReadOnly Property DisplayName As String
        Public ReadOnly Property Name As String
        Public ReadOnly Property Description As String
        Public ReadOnly Property Version As Integer
        Public ReadOnly Property Author As String
        Public ReadOnly Property VersionName As String
        Public ReadOnly Property ListenedReqs As String()
        Public ReadOnly Property ListenedCmds As String()
        Public ReadOnly Property Dependency As String
        Public ReadOnly Property First As Boolean



        Public Sub New(displayName As String, name As String, description As String, version As Integer, first As Boolean, author As String, versionName As String, dependency As String, listenedReqs As String(), listenedCmds As String())
            Me.DisplayName = displayName
            Me.Name = name
            Me.Description = description
            Me.Version = version
            Me.Author = author
            Me.VersionName = versionName
            Me.ListenedReqs = listenedReqs
            Me.First = first
            Me.ListenedCmds = listenedCmds
        End Sub




    End Class

End Namespace