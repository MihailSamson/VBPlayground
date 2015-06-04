Imports System.Web.Http

Namespace Controllers

    Public Class PingController : Inherits ApiController

        <HttpGet>
        Public Function Ping() As String

            Return "OK"

        End Function

    End Class
End Namespace