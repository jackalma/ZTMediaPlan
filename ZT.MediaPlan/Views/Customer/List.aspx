<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>List</title>
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/icon.css">
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/demo/demo.css">
    <script type="text/javascript" src="../../Scripts/easyui/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="../../Scripts/easyui/jquery.easyui.min.js"></script>
    <style type="text/css">
        #fm
        {
            margin: 0;
            padding: 10px 30px;
        }
        .ftitle
        {
            font-size: 14px;
            font-weight: bold;
            padding: 5px 0;
            margin-bottom: 10px;
            border-bottom: 1px solid #ccc;
        }
        .fitem
        {
            margin-bottom: 5px;
        }
        .fitem label
        {
            display: inline-block;
            width: 80px;
        }
    </style>
</head>
<body>  
    <table id="dg" title="客户管理列表" class="easyui-datagrid" style="width: 700px; height: 250px"
        url="/Customer/CustomerList" toolbar="#toolbar" pagination="true" rownumbers="true" fitcolumns="true"
        singleselect="true">
        <thead>
            <tr>
                <th field="firstname" width="50">
                    客户名称
                </th>
                <th field="lastname" width="50">
                    品牌
                </th>
                <th field="phone" width="50">
                    电话
                </th>
                <th field="email" width="50">
                    地址
                </th>
            </tr>
        </thead>
    </table>
    <div id="toolbar">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" plain="true"
            onclick="newUser()">新增客户</a> <a href="javascript:void(0)" class="easyui-linkbutton"
                iconcls="icon-edit" plain="true" onclick="editUser()">编辑客户</a> <a href="javascript:void(0)"
                    class="easyui-linkbutton" iconcls="icon-remove" plain="true" onclick="destroyUser()">
                    删除客户</a>
    </div>
    <div id="dlg" class="easyui-dialog" style="width: 400px; height: 280px; padding: 10px 20px"
        closed="true" buttons="#dlg-buttons">
        <div class="ftitle">
            客户信息</div>
        <form id="fm" method="post" novalidate>
        <div class="fitem">
            <label>
                客户名称:</label>
            <input name="firstname" class="easyui-validatebox" required="true">
        </div>
        <div class="fitem">
            <label>
                品牌:</label>
            <input name="lastname" class="easyui-validatebox" required="true">
        </div>
        <div class="fitem">
            <label>
                电话:</label>
            <input name="phone">
        </div>
        <div class="fitem">
            <label>
                地址:</label>
            <input name="email" class="easyui-validatebox" validtype="email">
        </div>
        </form>
    </div>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-ok" onclick="saveUser()">
            保存</a> <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel"
                onclick="javascript:$('#dlg').dialog('close')">取消</a>
    </div>
    <script type="text/javascript">
        var url;
//        $(function () {
//            $('#dg').datagrid({
//                url: 'datagrid_data.json',
//                columns: [[
//                        { field: 'code', title: 'Code', width: 100 },
//                        { field: 'name', title: 'Name', width: 100 },
//                        { field: 'price', title: 'Price', width: 100, align: 'right' }
//                            ]]
//            });
//        });


        function newUser() {
            $('#dlg').dialog('open').dialog('setTitle', '新增客户');
            $('#fm').form('clear');
            url = 'save_user.php';
        }
        function editUser() {
            var row = $('#dg').datagrid('getSelected');
            if (row) {
                $('#dlg').dialog('open').dialog('setTitle', 'Edit User');
                $('#fm').form('load', row);
                url = 'update_user.php?id=' + row.id;
            }
        }
        function saveUser() {
            $('#fm').form('submit', {
                url: url,
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (result) {
                    var result = eval('(' + result + ')');
                    if (result.errorMsg) {
                        $.messager.show({
                            title: 'Error',
                            msg: result.errorMsg
                        });
                    } else {
                        $('#dlg').dialog('close');        // close the dialog
                        $('#dg').datagrid('reload');    // reload the user data
                    }
                }
            });
        }
        function destroyUser() {
            var row = $('#dg').datagrid('getSelected');
            if (row) {
                $.messager.confirm('Confirm', 'Are you sure you want to destroy this user?', function (r) {
                    if (r) {
                        $.post('destroy_user.php', { id: row.id }, function (result) {
                            if (result.success) {
                                $('#dg').datagrid('reload');    // reload the user data
                            } else {
                                $.messager.show({    // show error message
                                    title: 'Error',
                                    msg: result.errorMsg
                                });
                            }
                        }, 'json');
                    }
                });
            }
        }
    </script>
</body>
</html>
