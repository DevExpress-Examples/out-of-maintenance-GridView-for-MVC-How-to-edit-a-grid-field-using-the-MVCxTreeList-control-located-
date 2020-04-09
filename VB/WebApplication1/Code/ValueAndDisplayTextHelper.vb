Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports WebApplication1.Models

Namespace WebApplication1.Code
    Public NotInheritable Class ValueAndDisplayTextHelper

        Private Sub New()
        End Sub

        Public Shared Function GetDisplayTextString(ByVal valuesString As String) As String
            Dim values = valuesString.Split(","c)
            Dim listOfText = Enumerable.Range(0, values.Length).Select(Function(r) LicensesDataProvider.GetLicenses().First(Function(s) s.LicenseID = Convert.ToInt32(values(r))).LicenseName)
            Return String.Join(",", listOfText)
        End Function
        Public Shared Function GetValueString(ByVal textsString As String) As String
            Dim texts = textsString.Split(","c)
            Dim listOfValues = Enumerable.Range(0, texts.Length).Select(Function(r) LicensesDataProvider.GetLicenses().First(Function(s) s.LicenseName = texts(r)).LicenseID.ToString())
            Return String.Join(",", listOfValues)
        End Function
    End Class
End Namespace