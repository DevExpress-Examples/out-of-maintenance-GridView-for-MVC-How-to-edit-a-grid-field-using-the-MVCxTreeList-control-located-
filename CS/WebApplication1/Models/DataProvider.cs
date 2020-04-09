using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public static class CustomersDataProvider {
        private static List<Customer> Customers {
            get {
                if (HttpContext.Current.Session["_gridData"] == null)
                    HttpContext.Current.Session["_gridData"] = GetNewCustomersList();
                return (List<Customer>)HttpContext.Current.Session["_gridData"];
            }
            set {
                HttpContext.Current.Session["_gridData"] = value;
            }
        }
        public static List<Customer> GetCustomers() {
            return Customers;
        }

        private static List<Customer> GetNewCustomersList() {
            return Enumerable.Range(0, 50).Select(s => new Customer {
                CustomerID = s,
                CustomerName = String.Format("Customer_{0}", s),
                Licenses = GetLicensesForCustomer(s)
            }).ToList();
        }

        internal static void InsertCustomer(Customer customer) {
            customer.CustomerID = Customers.Count;
            Customers.Add(customer);
        }

        private static string GetLicensesForCustomer(int customerID) {
            var licenses = string.Join(",", LicensesDataProvider.GetLicenses().Take(customerID % 8).Select(s => s.LicenseID));
            return licenses == String.Empty ? null : licenses;
        }

        public static void UpdateCustomer(Customer customer) {
            Customers[Customers.IndexOf(Customers.SingleOrDefault(s => s.CustomerID == customer.CustomerID))] = customer;
        }

        public static void DeleteCustomer(Customer customer) {
            Customers.RemoveAll(p => p.CustomerID == customer.CustomerID);
        }
    }
    public static class LicensesDataProvider {
        private static List<License> Licenses {
            get {
                return Enumerable.Range(0, 15).Select(s => new License {
                    LicenseID = s,
                    ParentLicenseID = s / 5,
                    LicenseName = String.Format("License_{0}_{1}", s / 5, s)
                }).ToList();
            }
        }
        public static List<License> GetLicenses() {
            return Licenses;
        }

    }
}