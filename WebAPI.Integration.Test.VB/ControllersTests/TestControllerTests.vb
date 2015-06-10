Imports System.Net.Http
Imports System.Net
Imports Newtonsoft.Json
Imports WebAPI.VB.Models
Imports NUnit.Framework

Namespace ControllersTests

    <TestFixture()>
    Public Class TestControllerTests
        Inherits IntegrationTestBase

        <Test()>
        Public Sub GetValuesTest()

            Dim response As HttpResponseMessage = Client.GetFunction("/api/test")

            Assert.IsTrue(response.StatusCode = HttpStatusCode.OK)

            Dim values As List(Of TestClass) = JsonConvert.DeserializeObject(Of List(Of TestClass))(response.Content.ReadAsStringAsync().Result)
            Assert.NotNull(values)
            Assert.IsTrue(values.Count = 2)
            
        End Sub

    End Class

End Namespace