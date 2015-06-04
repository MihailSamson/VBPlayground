Imports System.Web.Http
Imports WebAPI.VB.Services
Imports WebAPI.VB.Models

Namespace Controllers

    Public Class TestController : Inherits ApiController

        Private ReadOnly _testService As ITestService

        Sub New(ByVal testService As ITestService)
            _testService = testService
        End Sub


        ' GET api/test/values
        Public Function GetValues() As List(Of TestClass)

            Dim list As New List(Of TestClass)
            list.Add(_testService.GetIds())
            list.Add(_testService.GetIds())

            Return list

        End Function

    End Class
End Namespace