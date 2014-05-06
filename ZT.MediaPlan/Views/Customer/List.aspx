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
    <table id="dg" class="easyui-datagrid">
        <thead>
            <tr>
                <th field="CustomerNo" width="75">
                    客户编号
                </th>
                <th field="CustomerName" width="175">
                    客户简称
                </th>
                <th field="CustomerType" width="75">
                    客户类别
                </th>
                <th field="CreateTime" width="180">
                    建档日期
                </th>
                <th field="ReceiptType" width="90">
                    开票类型
                </th>
                <th field="Creator" width="100">
                    经办人
                </th>
                <th field="BusinessLicNo" width="130">
                    营业执照码
                </th>
                <th field="Bank" width="110">
                    开户银行
                </th>
                <th field="Status" width="75">
                    状态
                </th>
            </tr>
        </thead>
    </table>
    <%--   <div id="toolbar">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" plain="true"
            onclick="newUser()">新增客户</a> <a href="javascript:void(0)" class="easyui-linkbutton"
                iconcls="icon-edit" plain="true" onclick="editUser()">编辑客户</a> <a href="javascript:void(0)"
                    class="easyui-linkbutton" iconcls="icon-remove" plain="true" onclick="destroyUser()">
                    删除客户</a>
    </div>--%>
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

        $(function () {
            $('#dg').datagrid({
                title: '客户管理列表',
                iconCls: 'icon-edit', //图标  
                width: 700,
                height: 'auto',
                nowrap: false,
                striped: true,
                border: true,
                collapsible: false, //是否可折叠的  
                fit: true, //自动大小  
                url: '/Customer/CustomerList',
                //sortName: 'code',  
                //sortOrder: 'desc',  
                remoteSort: false,
                idField: 'fldId',
                singleSelect: false, //是否单选  
                pagination: true, //分页控件  
                rownumbers: false, //行号  
                frozenColumns: [[
            { field: 'ck', checkbox: true }
        ]],
                toolbar: [{
                    text: '新增客户',
                    iconCls: 'icon-add',
                    handler: function () {
                        newUser();
                    }
                }, '-', {
                    text: '编辑客户',
                    iconCls: 'icon-edit',
                    handler: function () {
                        editUser();
                    }
                }, '-', {
                    text: '删除客户',
                    iconCls: 'icon-remove',
                    handler: function () {
                        destroyUser();
                    }
                }]
            });

            //设置分页控件  
            var p = $('#dg').datagrid("getPager");
            $(p).pagination({
                pageSize: 10, //每页显示的记录条数，默认为10  
                pageList: [5, 10, 15], //可以设置每页记录条数的列表  
                beforePageText: '第', //页数文本框前显示的汉字  
                afterPageText: '页    共 {pages} 页',
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
                /*onBeforeRefresh:function(){ 
                $(this).pagination('loading'); 
                alert('before refresh'); 
                $(this).pagination('loaded'); 
                }*/
                onSelectPage: function () { alert(pageNumber + '/' + pageSize) },
                onChangePageSize: function () { alert(pageSize) }
            });
        });

       

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
