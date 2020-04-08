@Imports WebApplication1.Models
@ModelType          List(Of Customer)

@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "GridView1"
                                     settings.KeyFieldName = "CustomerID"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
                                     settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewAddNewPartial"}
                                     settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewUpdatePartial"}
                                     settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewDeletePartial"}
                                     settings.CommandColumn.Visible = True
                                     settings.CommandColumn.ShowEditButton = True
                                     settings.Columns.Add("CustomerID", MVCxGridViewColumnType.TextBox)
                                     settings.Columns.Add("CustomerName", MVCxGridViewColumnType.TextBox)
                                     settings.Columns.Add(Sub(col)
                                                              col.FieldName = "Licenses"
                                                              col.ColumnType = MVCxGridViewColumnType.TextBox
                                                              col.SetEditItemTemplateContent(Sub(tc)
                                                                                                 Html.DevExpress().DropDownEdit(Sub(ddeSettings)
                                                                                                                                    ddeSettings.Name = "Licenses"
                                                                                                                                    ddeSettings.SetDropDownWindowTemplateContent(Sub(ddec)
                                                                                                                                                                                     Html.RenderAction("TreeListPartial", New With {Key .ddeValue = DataBinder.Eval(tc.DataItem, "Licenses")})
                                                                                                                                                                                     Html.DevExpress().Button(Sub(btnSettings)
                                                                                                                                                                                                                  btnSettings.Name = "confirmBtn"
                                                                                                                                                                                                                  btnSettings.Text = "OK"
                                                                                                                                                                                                                  btnSettings.Width = New Unit(100, UnitType.Percentage)
                                                                                                                                                                                                                  btnSettings.ClientSideEvents.Click = "OnConfirmBtnClick"
                                                                                                                                                                                                              End Sub).Render()
                                                                                                                                                                                 End Sub)
                                                                                                                                    ddeSettings.Init = Sub(s, e)
                                                                                                                                                           Dim dde As MVCxDropDownEdit = CType(s, MVCxDropDownEdit)
                                                                                                                                                           dde.ClientSideEvents.QueryCloseUp = "OnDropDownEditQueryClose"
                                                                                                                                                           dde.Value = DataBinder.Eval(tc.DataItem, "Licenses")
                                                                                                                                                       End Sub
                                                                                                                                End Sub).Render()
                                                                                             End Sub)
                                                          End Sub)
                                 End Sub).Bind(Model).GetHtml()
