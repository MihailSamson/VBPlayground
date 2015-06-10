Imports System.Net.Http
Imports System.Net
Imports NUnit.Framework

Namespace ControllersTests

    <TestFixture()>
    Public Class PingControllerTests
        Inherits IntegrationTestBase

        <Test()>
        Public Sub GetValuesTest()

            Dim response As HttpResponseMessage = Client.GetFunction("/check")

            Assert.IsTrue(response.StatusCode = HttpStatusCode.OK)

            Dim value As String = response.Content.ReadAsStringAsync().Result
            Assert.NotNull(value)
            Assert.IsTrue(value.Equals("""OK"""))

        End Sub
    End Class
End Namespace