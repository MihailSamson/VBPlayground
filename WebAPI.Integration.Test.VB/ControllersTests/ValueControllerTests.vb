Imports System.Net.Http
Imports System.Net
Imports Newtonsoft.Json
Imports NUnit.Framework

Namespace ControllersTests

    <TestFixture()>
    Public Class ValueControllerTests
        Inherits IntegrationTestBase

        <Test()>
        Public Sub GetValuesTest()

            Dim response As HttpResponseMessage = Client.GetFunction("api/values")

            Assert.IsTrue(response.StatusCode = HttpStatusCode.OK)

            Dim values() As String = JsonConvert.DeserializeObject(Of String())(response.Content.ReadAsStringAsync().Result)
            Assert.NotNull(values)
            Assert.IsTrue(values.Count = 2)
            Assert.IsTrue(values(0) = "value1")
            Assert.IsTrue(values(1) = "value2")

        End Sub

        <Test()>
        Public Sub GetValueTest()

            Dim response As HttpResponseMessage = Client.GetFunction("api/values/5")

            Assert.IsTrue(response.StatusCode = HttpStatusCode.OK)

            Dim value As String = JsonConvert.DeserializeObject(Of String)(response.Content.ReadAsStringAsync().Result)
            Assert.NotNull(value)
            Assert.IsTrue(value = "value")

        End Sub

        <Test()>
        Public Sub PostValueTest()

            Dim obj As HttpContent

            Dim response As HttpResponseMessage = Client.PostFunction(obj, "api/values/5")

            Assert.IsTrue(response.StatusCode = HttpStatusCode.OK)

            Dim value As Integer = JsonConvert.DeserializeObject(Of Integer)(response.Content.ReadAsStringAsync().Result)
            Assert.NotNull(value)
            Assert.IsTrue(value = 1)

        End Sub

    End Class

End Namespace