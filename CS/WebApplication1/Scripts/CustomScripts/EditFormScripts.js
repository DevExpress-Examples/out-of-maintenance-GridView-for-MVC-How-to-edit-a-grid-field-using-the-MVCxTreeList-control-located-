function OnDropDownEditQueryClose(s, e) {
    TreeList1.GetSelectedNodeValues("LicenseID", function (values) { SetDropDownEditValue(values, s) });
}
function OnConfirmBtnClick(s, e) {
    Licenses.HideDropDown();
}
function SetDropDownEditValue(values, s) {
    let valueString = "";
    if (values != null && values.length > 0)
        valueString = valueString.concat(values);
    s.SetValue(valueString);
}
