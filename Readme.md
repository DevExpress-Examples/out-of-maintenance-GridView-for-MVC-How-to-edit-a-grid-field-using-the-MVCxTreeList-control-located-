# GridView for MVC - How to edit a grid field using the MVCxTreeList located inside MVCxDropDownEdit

This example illustrates how to:  
- Replace the default column editor with the MVCxDropDownEdit control and put the MVCxTreeList control into the dropdown window template;
- Implement the client-side logic to bind the MVCxDropDownEdit control value depending on the MVCxTreeList control selection;
- Implement the server-side logic to select MVCxTreeList nodes depending on the grid field value.


<!-- default file list --> 
*Files to look at*:

* [HomeController.cs](./CS/WebApplication1/Controllers/HomeController.cs)(VB: [HomeController.vb](./VB/WebApplication1/Controllers/HomeController.vb))
* [_GridViewPartial.cshtml](./CS/WebApplication1/Views/Home/_GridViewPartial.cshtml)(VB: [_GridViewPartial.vbhtml](./VB/WebApplication1/Views/Home/_GridViewPartial.vbhtml))
* [_TreeListPartial.cshtml](./CS/WebApplication1/Views/Home/_TreeListPartial.cshtml)(VB: [_TreeListPartial.vbhtml](./VB/WebApplication1/Views/Home/_TreeListPartial.vbhtml))
* [EditFormScripts.js](./CS/WebApplication1/Scripts/CustomScripts/EditFormScripts.js)

<!-- default file list end -->
