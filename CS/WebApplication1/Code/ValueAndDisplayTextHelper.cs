using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Code {
    public static class ValueAndDisplayTextHelper {
        public static string GetDisplayTextString(string valuesString) {
            var values = valuesString.Split(',');
            var listOfText = Enumerable.Range(0, values.Length).Select(r => LicensesDataProvider.GetLicenses().First(s => s.LicenseID == Convert.ToInt32(values[r])).LicenseName);
            return String.Join(",", listOfText);
        }
        public static string GetValueString(string textsString) {
            var texts = textsString.Split(',');
            var listOfValues = Enumerable.Range(0, texts.Length).Select(r => LicensesDataProvider.GetLicenses().First(s => s.LicenseName == texts[r]).LicenseID.ToString());
            return String.Join(",", listOfValues);
        }
    }
}