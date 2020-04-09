Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebApplication1.Models
    Public NotInheritable Class CustomersDataProvider

        Private Sub New()
        End Sub

        Private Shared Property Customers() As List(Of Customer)
            Get
                If HttpContext.Current.Session("_gridData") Is Nothing Then
                    HttpContext.Current.Session("_gridData") = GetNewCustomersList()
                End If
                Return CType(HttpContext.Current.Session("_gridData"), List(Of Customer))
            End Get
            Set(ByVal value As List(Of Customer))
                HttpContext.Current.Session("_gridData") = value
            End Set
        End Property
        Public Shared Function GetCustomers() As List(Of Customer)
            Return Customers
        End Function

        Private Shared Function GetNewCustomersList() As List(Of Customer)
            Return Enumerable.Range(0, 50).Select(Function(s) New Customer With {.CustomerID = s, .CustomerName = String.Format("Customer_{0}", s), .Licenses = GetLicensesForCustomer(s)}).ToList()
        End Function

        Friend Shared Sub InsertCustomer(ByVal customer As Customer)
            customer.CustomerID = Customers.Count
            Customers.Add(customer)
        End Sub

        Private Shared Function GetLicensesForCustomer(ByVal customerID As Integer) As String
            Dim licenses = String.Join(",", LicensesDataProvider.GetLicenses().Take(customerID Mod 8).[Select](Function(s) s.LicenseID))
            Return If(licenses = String.Empty, Nothing, licenses)
        End Function

        Public Shared Sub UpdateCustomer(ByVal customer As Customer)
            Customers(Customers.IndexOf(Customers.SingleOrDefault(Function(s) s.CustomerID = customer.CustomerID))) = customer
        End Sub

        Public Shared Sub DeleteCustomer(ByVal customer As Customer)
            Customers.RemoveAll(Function(p) p.CustomerID = customer.CustomerID)
        End Sub
    End Class
    Public NotInheritable Class LicensesDataProvider

        Private Sub New()
        End Sub

        Private Shared ReadOnly Property Licenses() As List(Of License)
            Get
                Return Enumerable.Range(0, 15).Select(Function(s) New License With {.LicenseID = s, .ParentLicenseID = s / 5, .LicenseName = String.Format("License_{0}_{1}", Math.Floor(s / 5), s)}).ToList()
            End Get
        End Property
        Public Shared Function GetLicenses() As List(Of License)
            Return Licenses
        End Function

    End Class
End Namespace