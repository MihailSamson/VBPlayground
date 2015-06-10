Imports Serilog
Imports WebAPI.Integration.Test.VB.Helpers
Imports NUnit.Framework
Imports Microsoft.Owin.Hosting
Imports System.Configuration

<SetUpFixture()>
Public Class TestsStartUp

    Private _logger As ILogger

    Private _identityServer As IDisposable

    Private _webApi As IDisposable

    Public Sub New()

    End Sub

    <SetUp()>
    Public Sub SetUp()

        ' Check that Configuration file is loaded properly
        'Assert.IsTrue(Not (String.IsNullOrEmpty(Config.IdentityServerUrl)))
        Assert.IsTrue(Not (String.IsNullOrEmpty(Config.ApiHostUrl)))

        Try

            ConfigureLogging()
            _logger = Log.ForContext(GetType(TestsStartUp))
            _logger.Debug("SetUp started.")

            'CleanUpDatabases();
            'AutoMapperConfiguration.Configure();

            ' ensure IdentityServer and WebAPI is stopped since previous run
            TearDown()

            'StartIdentityServer()
            StartWebApi()
            _logger.Debug("SetUp finished.")

        Catch e As Exception

            _logger.Error(e, "Exception during SetUp.")

            StopWebApi()
            StopIdentityServer()

            Assert.Fail("Tests start up failed. Exception: {0}", e)

        End Try

    End Sub

    Private Sub ConfigureLogging()

        Log.Logger = New LoggerConfiguration().ReadFrom.AppSettings().Enrich.WithThreadId().Enrich.FromLogContext().CreateLogger()

    End Sub

    <TearDown()>
    Public Sub TearDown()

        StopIdentityServer()
        StopWebApi()

    End Sub

    Private Sub StopIdentityServer()

        If (Not (_identityServer Is Nothing)) Then
            _identityServer.Dispose()
            _identityServer = Nothing
            _logger.Information("IdentityServer has been stopped.")
        End If

    End Sub

    Private Sub StopWebApi()

        If (Not (_webApi Is Nothing)) Then
            _webApi.Dispose()
            _webApi = Nothing
            _logger.Information("WebApi has been stopped.")
        End If

    End Sub

    Private Sub StartIdentityServer()

        Dim identityServerHostUrl As New Uri(Config.IdentityServerUrl)
        Dim identityServerHostString As String = identityServerHostUrl.GetLeftPart(UriPartial.Authority).Replace("localhost", "*")

        '_identityServer = WebApp.Start(identityServerHostString, IdentityServerStartup)
        _logger.Information("IdentityServer has been started.")

    End Sub

    Private Sub StartWebApi()

        _webApi = WebApp.Start(Of WebAPI.VB.Startup)(Config.ApiHostUrl)
        _logger.Information("WebApi has been started.")

    End Sub

End Class
