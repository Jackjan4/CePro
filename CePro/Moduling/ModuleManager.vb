Imports De.JanRoslan.CePro.My
Imports De.JanRoslan.CePro.Net
Imports System.IO
Imports System.Reflection

Namespace Moduling

    Public NotInheritable Class ModuleManager

        Private Shared ReadOnly _instance As New Lazy(Of ModuleManager)(Function() New ModuleManager(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)

        Public Shared ReadOnly Property Instance() As ModuleManager
            Get
                Return _instance.Value
            End Get
        End Property

        Private Property ModulesByReq As Dictionary(Of String, AppModule)


        Private Sub New()
            ModulesByReq = New Dictionary(Of String, AppModule)

            'loadModules()

            'initModules()
        End Sub







        Sub ProcessInModules(req As ClientRequest)


        End Sub

        Sub ProcessInModules(req As ConsoleRequest)

        End Sub


        Sub LoadModules()

            Dim path = MySettings.Default.ModulePath

            ' Listing all modules
            For Each file As String In Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                Dim ass As Assembly = Assembly.LoadFrom(file)

                Dim results As IEnumerable(Of Type) = From a In ass.GetTypes
                                                      Where GetType(BaseModule).IsAssignableFrom(a)
                                                      Select a

                results(0)
            Next

        End Sub

    End Class




End Namespace