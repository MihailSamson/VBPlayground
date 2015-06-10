Imports System.Net.Http
Imports Serilog
Imports System.Threading

Namespace Helpers

    Public Class ApiClient

        Private ReadOnly _logger As ILogger = Log.ForContext(GetType(ApiClient))

        Private AccessToken As String

        Public Function GetFunction(uri As String) As HttpResponseMessage

            Return GetResponse(Function(c) c.GetAsync(uri))

        End Function

        Public Function PostFunction(payload As Object, uri As String) As HttpResponseMessage

            Return GetResponse(Function(c) c.PostAsync(uri, payload))

        End Function

        Private Function GetResponse(callToApi As Func(Of HttpClient, Task(Of HttpResponseMessage))) As HttpResponseMessage

            Dim apiUrl As String = Config.ApiHostUrl.Replace("*", "localhost")
            Dim client As New HttpClient
            client.BaseAddress = New Uri(apiUrl)

            If (AccessToken Is Nothing) Then
                'AccessToken = TokenClient.GetToken(Config.IdentityServerUrl).AccessToken
            End If

            'Thread.Sleep(30000)
            'client.SetBearerToken(AccessToken)

            _logger.Debug("Web API call to {0} started.", apiUrl)
            Dim response As HttpResponseMessage = callToApi(client).Result
            _logger.Debug("Web API call to {0} finished.", apiUrl)

            Return response

        End Function

        'Public Function Token(userName As String, password As String) As ApiClient

        '    Dim token As TokenResponse = TokenClient.GetToken(Config.IdentityServerUrl, userName, password)

        '    Dim apiClient As New ApiClient()
        '    apiClient.AccessToken = token

        '    Return apiClient

        'End Function

    End Class

End Namespace