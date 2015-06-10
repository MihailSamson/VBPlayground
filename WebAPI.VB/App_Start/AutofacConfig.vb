Imports System.Reflection
Imports System.Web.Http
Imports Autofac
Imports Autofac.Core
Imports Autofac.Integration.WebApi
Imports WebAPI.VB.Services

Namespace App_Start

    Public Class AutofacConfig

        Public Shared Sub Register(ByRef configuration As HttpConfiguration)

            Dim containerBuilder As New ContainerBuilder()
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly())
            containerBuilder.RegisterWebApiFilterProvider(configuration)
            containerBuilder.RegisterType(Of TestService).As(Of ITestService)()

            Dim container As Container = containerBuilder.Build()
            Dim resolver As New AutofacWebApiDependencyResolver(container)

            configuration.DependencyResolver = resolver

        End Sub

    End Class
End Namespace