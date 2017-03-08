Namespace Moduling

    <AttributeUsage(AttributeTargets.Class)>
    Public Class ModuleInfo
        Inherits Attribute

        Public ReadOnly Property Name As String
        Public ReadOnly Property Description As String
        Public ReadOnly Property Version As Integer
        Public ReadOnly Property Author As String
        Public ReadOnly Property VersionName As String



        Public Sub New(name As String, description As String, version As Integer, author As String, versionName As String)
            Me.Name = name
            Me.Description = description
            Me.Version = version
            Me.Author = author
            Me.VersionName = versionName
        End Sub




    End Class

End Namespace