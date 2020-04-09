function OnDropDownEditQueryClose(s, e) {
    TreeList1.GetSelectedNodeValues("LicenseName", OnGetSelectedNodeValues);
}
function OnConfirmBtnClick(s, e) {
    DropDownEdit1.HideDropDown();
}
function OnGetSelectedNodeValues(values) {
    let valueString = "";
    if (values != null && values.length > 0)
        valueString = valueString.concat(values);
    DropDownEdit1.SetValue(valueString);
}

function OnTreeListEndCallback(s, e) {
    if (e.command != "CustomCallback") return;
    updateText();
}

function updateText() {    
    DropDownEdit1.SetText(TreeList1.cp_selectedTexts);
}
function synchronizeTreeListValues(s, e) {    
    var texts = s.GetText();
    TreeList1.PerformCallback({ textsString: texts });        
}

