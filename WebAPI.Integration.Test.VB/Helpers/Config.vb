Imports System.Configuration

Namespace Helpers
    Public Class Config

        Public Shared ReadOnly ApiHostUrl As String = My.Settings.ApiHostUrl '.FixUpUrl()

        Public Shared ReadOnly IdentityServerUrl As String = ConfigurationManager.AppSettings("IdentityServerUrl") '.FixUpUrl()

    End Class
End Namespace