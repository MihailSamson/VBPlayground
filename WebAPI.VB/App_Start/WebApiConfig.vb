Imports System.Web.Http
Imports System.Net.Http.Formatting
Imports System.Net.Http.Headers

Public Class WebApiConfig

    Public Shared Sub Register(ByVal config As HttpConfiguration)
        config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{id}", defaults:=New With {.id = RouteParameter.Optional})
        config.Routes.MapHttpRoute( _
            "availability", _
            "check", _
            New With {.controller = "Ping", .action = "Ping"} _
        )

        Dim json As JsonMediaTypeFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter
        json.UseDataContractJsonSerializer = True
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))

        config.EnableSystemDiagnosticsTracing()
    End Sub

End Class