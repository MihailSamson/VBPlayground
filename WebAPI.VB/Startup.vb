Imports System.Web.Http
Imports Owin
Imports WebAPI.VB.App_Start

Public Class Startup

    Public Sub Configuration(app As IAppBuilder)

        Dim config As New HttpConfiguration()

        AutofacConfig.Register(config)
        WebApiConfig.Register(config)

        app.UseWebApi(config)

    End Sub

End Class

