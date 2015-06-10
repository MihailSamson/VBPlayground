Imports System.Web.Http

Namespace Controllers

    Public Class ValuesController
        Inherits ApiController

        ' GET api/values
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET api/values/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST api/values
        Public Function PostValue(<FromBody()> ByVal value As String) As Integer
            ' process request, return Id
            Return 1
        End Function

    End Class
End Namespace