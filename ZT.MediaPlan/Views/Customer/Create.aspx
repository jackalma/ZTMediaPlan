<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>新增客户</title>
    <link href="../../Scripts/liger/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Scripts/liger/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerPanel.js" type="text/javascript"></script>
    <link href="../../Scripts/liger/ligerUI/skins/Tab/css/form.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Scripts/liger/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/jquery-validation/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var groupicon = "";
        var form;
        var area_data = [
            { id: '11', value: '11', text: '北京市' },
            { id: '22', value: '22', text: '广州市' },
            { id: '33', value: '33', text: '苏州市' },
            { id: '44', value: '44', text: '杜洲市' }
        ];
        $(function () {
            $("#panel2").ligerPanel({
                title: '表单',
                width: 700,
                height: 500              
            });

            //创建表单结构 
            form = $("#form2").ligerForm({
                inputWidth: 170, labelWidth: 90, space: 40,

                fields: [
                { name: "ProductID", type: "hidden" },
                { display: "日期 ", name: "AddTime", newline: true, type: "date", validate: { required: true, minlength: 5} },
                { display: "折扣", name: "QuantityPerUnit", newline: true, type: "number", validate: { required: true, minlength: 5} },
                { display: "单价", name: "UnitPrice", newline: true, type: "number", editor: { readonly: true }, validate: { required: true, minlength: 5} },
                { display: "库存量", name: "UnitsInStock", newline: true, type: "digits", group: "库存", groupicon: groupicon },
                { display: "订购量", name: "UnitsOnOrder", newline: true, type: "digits" },
                { display: "采购量", name: "UnitsOnOrder2", newline: true, type: "spinner" },
                 { display: "选择公司", name: "Company", newline: true, type: "popup" },
              { display: "地区", name: "Area", newline: false, type: "select", editor: { data: area_data} },
                { display: "备注", name: "Remark", newline: true, type: "text", width: 470, validate: { required: true, minlength: 5} },
                { display: "备注", name: "Remark", newline: true, type: "text", width: 470 }
                ]



                //fields:[{ "name": "ProductID", "type": "hidden" }, { "label": "产品名称", "name": "ProductName", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "text", "group": "基础信息", "groupicon": "group.gif" }, { "label": "供应商", "name": "SupplierID", "width": 170, "labelWidth": 90, "space": 40, "newline": false, "type": "combobox", "textField": "CompanyName", "editor": { "data": [{ "id": 0, "value": 0, "text": "[数据0]" }, { "id": 1, "value": 1, "text": "[数据1]" }, { "id": 2, "value": 2, "text": "[数据2]" }, { "id": 3, "value": 3, "text": "[数据3]" }, { "id": 4, "value": 4, "text": "[数据4]" }, { "id": 5, "value": 5, "text": "[数据5]" }, { "id": 6, "value": 6, "text": "[数据6]" }, { "id": 7, "value": 7, "text": "[数据7]" }, { "id": 8, "value": 8, "text": "[数据8]"}], "grid": { "columns": [{ "display": "ID", "name": "id" }, { "display": "Text", "name": "text"}], "data": { "Rows": [{ "id": 0, "value": 0, "text": "[数据0]" }, { "id": 1, "value": 1, "text": "[数据1]" }, { "id": 2, "value": 2, "text": "[数据2]" }, { "id": 3, "value": 3, "text": "[数据3]" }, { "id": 4, "value": 4, "text": "[数据4]" }, { "id": 5, "value": 5, "text": "[数据5]" }, { "id": 6, "value": 6, "text": "[数据6]" }, { "id": 7, "value": 7, "text": "[数据7]" }, { "id": 8, "value": 8, "text": "[数据8]"}]} }, "selectBoxWidth": 400, "selectBoxHeight": 200 }, "group": "基础信息", "groupicon": "group.gif" }, { "label": "类别 ", "name": "CategoryID", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "select", "textField": "CategoryName", "editor": { "data": [{ "id": 0, "value": 0, "text": "[数据0]" }, { "id": 1, "value": 1, "text": "[数据1]" }, { "id": 2, "value": 2, "text": "[数据2]" }, { "id": 3, "value": 3, "text": "[数据3]" }, { "id": 4, "value": 4, "text": "[数据4]" }, { "id": 5, "value": 5, "text": "[数据5]" }, { "id": 6, "value": 6, "text": "[数据6]" }, { "id": 7, "value": 7, "text": "[数据7]" }, { "id": 8, "value": 8, "text": "[数据8]"}] }, "group": "基础信息", "groupicon": "group.gif" }, { "label": "供应商2", "name": "SupplierID2", "width": 170, "labelWidth": 90, "space": 40, "newline": false, "type": "popup", "textField": "CompanyName2", "editor": { "data": [{ "id": 0, "value": 0, "text": "[数据0]" }, { "id": 1, "value": 1, "text": "[数据1]" }, { "id": 2, "value": 2, "text": "[数据2]" }, { "id": 3, "value": 3, "text": "[数据3]" }, { "id": 4, "value": 4, "text": "[数据4]" }, { "id": 5, "value": 5, "text": "[数据5]" }, { "id": 6, "value": 6, "text": "[数据6]" }, { "id": 7, "value": 7, "text": "[数据7]" }, { "id": 8, "value": 8, "text": "[数据8]"}], "grid": { "columns": [{ "display": "ID", "name": "id" }, { "display": "Text", "name": "text"}], "data": { "Rows": [{ "id": 0, "value": 0, "text": "[数据0]" }, { "id": 1, "value": 1, "text": "[数据1]" }, { "id": 2, "value": 2, "text": "[数据2]" }, { "id": 3, "value": 3, "text": "[数据3]" }, { "id": 4, "value": 4, "text": "[数据4]" }, { "id": 5, "value": 5, "text": "[数据5]" }, { "id": 6, "value": 6, "text": "[数据6]" }, { "id": 7, "value": 7, "text": "[数据7]" }, { "id": 8, "value": 8, "text": "[数据8]"}]} }, "selectBoxWidth": 400, "selectBoxHeight": 200 }, "group": "基础信息", "groupicon": "group.gif" }, { "label": "日期 ", "name": "AddTime", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "date", "group": "基础信息", "groupicon": "group.gif" }, { "label": "折扣", "name": "QuantityPerUnit", "width": 170, "labelWidth": 90, "space": 40, "newline": false, "type": "number", "group": "基础信息", "groupicon": "group.gif" }, { "label": "单价", "name": "UnitPrice", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "number", "group": "基础信息", "groupicon": "group.gif" }, { "label": "库存量", "name": "UnitsInStock", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "digits", "group": "库存", "groupicon": "group.gif" }, { "label": "订购量", "name": "UnitsOnOrder", "width": 170, "labelWidth": 90, "space": 40, "newline": false, "type": "digits", "group": "库存", "groupicon": "group.gif" }, { "label": "备注", "name": "Remark", "labelWidth": 90, "space": 40, "newline": true, "type": "textarea", "width": 470, "group": "库存", "groupicon": "group.gif" }, { "label": "产品名称", "name": "ProductName", "width": 170, "labelWidth": 90, "space": 40, "newline": true, "type": "text", "group": "基础信息", "groupicon": "group.gif"}]



            });

        });
        

    </script>
</head>
<body>
    <%-- <div style="width: 100%;">
        <div ligeruiid="panel1-1" class="l-panel" id="panel1-1" style="float: left; width: 400px;">
            <div class="l-panel-header">
                <span>标题</span><div class="icons">
                    <div class="l-panel-header-toggle">
                    </div>
                </div>
            </div>
            <div style="height: 275px;" class="l-panel-content">
                这里是内容111。。。。
            </div>
        </div>
        <div ligeruiid="panel1-2" class="l-panel" id="panel1-2" style="float: left; margin-left: 10px;
            width: 400px;">
            <div class="l-panel-header">
                <span>标题</span><div class="icons">
                    <div class="l-panel-header-toggle">
                    </div>
                </div>
            </div>
            <div style="height: 275px;" class="l-panel-content">
                这里是内容222。。。。
            </div>
        </div>
        <div class="l-clear">
        </div>
    </div>--%>
    <div ligeruiid="panel2" class="l-panel" id="panel2" style="margin-top: 10px; clear: both;
        width: 700px;">
        <div class="l-panel-header">
            <span>基本信息</span><div class="icons">
                <div class="l-panel-header-toggle">
                </div>
            </div>
        </div>
        <div style="height: 475px;" class="l-panel-content">
            <form id="form2">
            </form>
            <div class="liger-button" data-click="f_validate" data-width="150">
                验证</div>
            <div class="l-panel-loading" style="display: none;">
            </div>
        </div>
    </div>
</body>
</html>
