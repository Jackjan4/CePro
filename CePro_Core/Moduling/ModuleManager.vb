Imports System.IO
Imports System.Text.Encoding
Imports System.Reflection
Imports De.JanRoslan.CePro.Core.Net
Imports De.JanRoslan.CePro.Core.My
Imports De.JanRoslan.NETUtils.Logging
Imports De.JanRoslan.CePro.Core.Console

Namespace Moduling

    Public NotInheritable Class ModuleManager

        Private Shared ReadOnly _instance As New Lazy(Of ModuleManager)(Function() New ModuleManager(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)

        Public Shared ReadOnly Property Instance As ModuleManager
            Get
                Return _instance.Value
            End Get
        End Property

        ' The modules, saved by the requests theya listen to
        Private Property ModulesByReq As Dictionary(Of String, AppModule)

        ' The modules
        Private Property Modules As HashSet(Of AppModule)




        Private Sub New()
            ModulesByReq = New Dictionary(Of String, AppModule)
            Modules = New HashSet(Of AppModule)

            LoadModules()

            InitModules()

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="req"></param>
        Sub ProcessInModules(req As ClientRequest)

            Dim procStack As New Stack(Of AppModule)



            ModulesByReq(UTF8.GetString(req.GetMessageHeader)).Process(req)

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="req"></param>
        Sub ProcessInModules(req As ConsoleRequest)

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Sub LoadModules()

            Dim path = MySettings.Default.ModulePath

            ' Listing all modules
            For Each file As String In Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                Dim ass As Assembly = Assembly.LoadFrom(file)

                ' Search for IBaseModule implementation
                Dim results As IEnumerable(Of Type) = From a In ass.GetTypes
                                                      Where GetType(IBaseModule).IsAssignableFrom(a)
                                                      Select a

                ' Load module class
                Dim appM As New AppModule(DirectCast(Activator.CreateInstance(results(0)), IBaseModule))

                Modules.Add(appM)
                Logging.Logger.Instance.Log("Loaded module """ & appM.Name & """ " & appM.Version & " by " & appM.Author, LogLevel.INFO, "ModuleManager")

                ' Add module to ModulesByReq
                For Each req As String In appM.ListenedReqs
                    ModulesByReq(req) = appM
                Next

                ' Add modules to ModulesByCmd


            Next

        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        Sub InitModules()

            For Each modu As AppModule In Modules
                modu.Init()
            Next
        End Sub

    End Class




End Namespace