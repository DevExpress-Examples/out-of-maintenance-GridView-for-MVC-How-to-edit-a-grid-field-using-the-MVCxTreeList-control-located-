@Imports WebApplication1.Models

@ModelType List(Of License)

@Functions
    Public Sub OnDataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim treeList As MVCxTreeList = CType(sender, MVCxTreeList)
        If ViewData("ddeValue") IsNot Nothing AndAlso ViewData("ddeValue").ToString() <> String.Empty Then SelectNodes(ViewData("ddeValue").ToString(), treeList)
    End Sub

    Public Sub SelectNodes(ByVal ddeValue As String, ByVal treeList As MVCxTreeList)
        Dim nodesKeys = ddeValue.Split(","c).ToList()

        For Each nodeKey In nodesKeys
            Dim node = treeList.FindNodeByKeyValue(nodeKey)
            node.Selected = node IsNot Nothing
        Next
    End Sub
End Functions

@Html.DevExpress().TreeList(Sub(settings)
                                     settings.Name = "TreeList1"

                                     settings.KeyFieldName = "LicenseID"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListPartial"}
                                     settings.Columns.Add("LicenseName", MVCxTreeListColumnType.TextBox)
                                     settings.Columns.Add("LicenseID", MVCxTreeListColumnType.TextBox)
                                     settings.ParentFieldName = "ParentLicenseID"
                                     settings.SettingsSelection.Enabled = True
                                     settings.SettingsSelection.AllowSelectAll = True
                                     settings.DataBound = Sub(s, e)
                                                              OnDataBound(s, e)
                                                          End Sub
                                 End Sub
                                             ).Bind(Model).GetHtml()

