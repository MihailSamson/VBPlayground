Imports System.Reflection
Imports System.Web.Http
Imports Autofac
Imports Autofac.Core
Imports Autofac.Integration.WebApi
Imports WebAPI.VB.Services

Namespace App_Start

    Public Class AutofacConfig

        'public static void Register(HttpConfiguration configuration)
        '    {
        '        var containerBuilder = new ContainerBuilder();

        '        containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        '        containerBuilder.RegisterWebApiFilterProvider(configuration);
        '        containerBuilder.RegisterModule(new ConfigurationSettingsReader());

        '        var container = containerBuilder.Build();

        '        var resolver = new AutofacWebApiDependencyResolver(container);

        '        // Configure Web API with the dependency resolver.
        '        configuration.DependencyResolver = resolver;
        '    }
        Public Shared Function Register(ByRef configuration As HttpConfiguration)

            Dim containerBuilder As New ContainerBuilder()
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly())
            containerBuilder.RegisterWebApiFilterProvider(configuration)
            containerBuilder.RegisterType(Of TestService).As(Of ITestService)()

            Dim container As Container = containerBuilder.Build()
            Dim resolver As New AutofacWebApiDependencyResolver(container)

            GlobalConfiguration.Configuration.DependencyResolver = resolver

        End Function

    End Class
End Namespace