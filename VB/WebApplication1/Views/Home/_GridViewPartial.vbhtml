@Imports WebApplication1.Models
@Imports WebApplication1.Code
@ModelType          List(Of Customer)

@Functions
    Public Sub OnCustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
        If e.Column.FieldName <> "Licenses" OrElse e.Value Is Nothing Then Return
        e.DisplayText = ValueAndDisplayTextHelper.GetDisplayTextString(e.Value.ToString())
    End Sub
End Functions

@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "GridView1"
                                     settings.KeyFieldName = "CustomerID"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
                                     settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewAddNewPartial"}
                                     settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewUpdatePartial"}
                                     settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewDeletePartial"}
                                     settings.CommandColumn.Visible = True
                                     settings.CommandColumn.ShowEditButton = True
                                     settings.CommandColumn.ShowNewButtonInHeader = True
                                     settings.CustomColumnDisplayText = Sub(s, e)
                                                                            OnCustomColumnDisplayText(s, e)
                                                                        End Sub
                                     settings.Columns.Add("CustomerID", MVCxGridViewColumnType.TextBox)
                                     settings.Columns.Add("CustomerName", MVCxGridViewColumnType.TextBox)
                                     settings.Columns.Add(Sub(col)
                                                              'DropDownEdit
                                                              col.FieldName = "Licenses"
                                                              col.ColumnType = MVCxGridViewColumnType.TextBox
                                                              col.SetEditItemTemplateContent(Sub(tc)
                                                                                                 Html.DevExpress().DropDownEdit(Sub(ddeSettings)
                                                                                                                                    ddeSettings.Name = "DropDownEdit1"
                                                                                                                                    ddeSettings.Properties.ClientSideEvents.TextChanged = "synchronizeTreeListValues"
                                                                                                                                    ddeSettings.Properties.ClientSideEvents.DropDown = "synchronizeTreeListValues"
                                                                                                                                    ddeSettings.Properties.ClientSideEvents.QueryCloseUp = "OnDropDownEditQueryClose"
                                                                                                                                    ddeSettings.Width = New Unit(100, UnitType.Percentage)
                                                                                                                                    ddeSettings.SetDropDownWindowTemplateContent(Sub(ddec)
                                                                                                                                                                                     'TreeList
                                                                                                                                                                                     Html.ViewContext.Writer.Write("<div class='ctrlContainer'>")
                                                                                                                                                                                     Html.RenderAction("TreeListPartial")
                                                                                                                                                                                     'Button
                                                                                                                                                                                     Html.ViewContext.Writer.Write("</div>")
                                                                                                                                                                                     Html.ViewContext.Writer.Write("<div class='ctrlContainer'>")
                                                                                                                                                                                     Html.DevExpress().Button(Sub(btnSettings)
                                                                                                                                                                                                                  btnSettings.Name = "confirmBtn"
                                                                                                                                                                                                                  btnSettings.Text = "OK"
                                                                                                                                                                                                                  btnSettings.Width = New Unit(98, UnitType.Percentage)
                                                                                                                                                                                                                  btnSettings.Style.Add(HtmlTextWriterStyle.Margin, "0px!important")
                                                                                                                                                                                                                  btnSettings.ClientSideEvents.Click = "OnConfirmBtnClick"
                                                                                                                                                                                                              End Sub).Render()
                                                                                                                                                                                     Html.ViewContext.Writer.Write("</div>")
                                                                                                                                                                                 End Sub)
                                                                                                                                    ddeSettings.Init = Sub(s, e)
                                                                                                                                                           Dim dde As MVCxDropDownEdit = CType(s, MVCxDropDownEdit)
                                                                                                                                                           Dim value = DataBinder.Eval(tc.DataItem, "Licenses")
                                                                                                                                                           dde.Value = If(value Is Nothing, Nothing, ValueAndDisplayTextHelper.GetDisplayTextString(value.ToString()))
                                                                                                                                                       End Sub
                                                                                                                                End Sub).Render()
                                                                                             End Sub)
                                                          End Sub)
                                 End Sub).Bind(Model).GetHtml()
