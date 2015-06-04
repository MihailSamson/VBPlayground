Imports WebAPI.VB.Models

Namespace Services
    Public Class TestService : Implements ITestService

        Public Function GetIds() As TestClass Implements ITestService.GetIds

            Dim v As New TestClass
            v.Name = "alex"
            v.Age = 1

            Return v

        End Function

    End Class
End Namespace
