' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
Imports System.Web.Optimization
Imports WebAPI.VB.App_Start

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()

        Dim config As HttpConfiguration = GlobalConfiguration.Configuration

        AutofacConfig.Register(config)
        AreaRegistration.RegisterAllAreas()
        WebApiConfig.Register(config)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class
