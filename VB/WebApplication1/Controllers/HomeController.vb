Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports WebApplication1.Models

Namespace WebApplication1.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function TreeListPartial(ByVal ddeValue As String) As ActionResult
			ViewData("ddeValue") = ddeValue
			Return PartialView("_TreeListPartial", LicensesDataProvider.GetLicenses())
		End Function
		Public Function GridViewPartial() As ActionResult
			Return PartialView("_GridViewPartial", CustomersDataProvider.GetCustomers())
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewAddNewPartial(ByVal customer As Customer) As ActionResult
			CustomersDataProvider.InsertCustomer(customer)
			Return GridViewPartial()
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewUpdatePartial(ByVal customer As Customer) As ActionResult
			CustomersDataProvider.UpdateCustomer(customer)
			Return GridViewPartial()
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewDeletePartial(Optional ByVal ID As Integer = -1) As ActionResult
			If ID <> -1 Then
				CustomersDataProvider.DeleteCustomer(New Customer With {.CustomerID = ID})
			End If
			Return GridViewPartial()
		End Function
	End Class
End Namespace