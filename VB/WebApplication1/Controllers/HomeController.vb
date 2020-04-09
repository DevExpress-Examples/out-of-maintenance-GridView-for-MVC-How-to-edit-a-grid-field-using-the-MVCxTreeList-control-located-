Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication1.Code
Imports WebApplication1.Models

Namespace WebApplication1.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function TreeListPartial() As ActionResult
            Return PartialView("_TreeListPartial", LicensesDataProvider.GetLicenses())
        End Function
        Public Function TreeListCustomPartial(ByVal textsString As String) As ActionResult
            ViewBag.Selection = textsString
            Return PartialView("_TreeListPartial", LicensesDataProvider.GetLicenses())
        End Function

        Public Function GridViewPartial() As ActionResult
            Return PartialView("_GridViewPartial", CustomersDataProvider.GetCustomers())
        End Function
        <HttpPost, ValidateInput(False)>
        Public Function GridViewAddNewPartial(ByVal customer As Customer) As ActionResult
            CustomersDataProvider.InsertCustomer(customer)
            Return GridViewPartial()
        End Function
        <HttpPost, ValidateInput(False)>
        Public Function GridViewUpdatePartial(ByVal customer As Customer) As ActionResult
            Dim dropDownEditText = DropDownEditExtension.GetValue(Of String)("DropDownEdit1")
            Dim fieldValue = ValueAndDisplayTextHelper.GetValueString(dropDownEditText)
            customer.Licenses = fieldValue
            CustomersDataProvider.UpdateCustomer(customer)
            Return GridViewPartial()
        End Function
        <HttpPost, ValidateInput(False)>
        Public Function GridViewDeletePartial(Optional ByVal ID As Integer = -1) As ActionResult
            If ID <> -1 Then
                CustomersDataProvider.DeleteCustomer(New Customer With {.CustomerID = ID})
            End If
            Return GridViewPartial()
        End Function
    End Class
End Namespace