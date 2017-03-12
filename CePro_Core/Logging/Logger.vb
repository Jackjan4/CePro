Imports De.JanRoslan.CePro.Core.My
Imports De.JanRoslan.NETUtils.Logging

Namespace Logging

    Public Class Logger

        Private Shared ReadOnly _instance As New Lazy(Of Logger)(Function() New Logger(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)

        Public Shared ReadOnly Property Instance As Logger
            Get
                Return _instance.Value
            End Get
        End Property


        Private ReadOnly Property InternalLogger As NETUtils.Logging.Logger


        Private Sub New()

            InternalLogger = New NETUtils.Logging.Logger.Builder() _
            .RegisterConsole(LogLevel.CONSOLE, LogLevel.ERROR, LogLevel.CRITICAL, LogLevel.INFO) _
            .RegisterFile(MySettings.Default.LogFile, LogLevel.CONSOLE, LogLevel.ERROR, LogLevel.CRITICAL, LogLevel.INFO) _
            .Build()


        End Sub

        Sub Log(message As String, Optional level As LogLevel = LogLevel.NONE, Optional header As String = "")

            InternalLogger.Log(message, level, header)
        End Sub
    End Class

End Namespace