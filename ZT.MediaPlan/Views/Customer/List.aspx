<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>List</title>
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/demo/demo.css" />
    <link rel="Stylesheet" type="text/css" href="../../Scripts/easyui/themes/ztsty.css" />
    <script type="text/javascript" src="../../Scripts/easyui/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="../../Scripts/easyui/jquery.easyui.min.js"></script>
    <style type="text/css">
        #fm
        {
            margin: 0;
            padding: 10px 20px;
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
            margin-bottom: 15px;
        }
        .fitem label
        {
            display: inline-block;
            width: 70px;            
            text-align:right;
            margin-left:15px;
        }        
    </style>
</head>
<body>
    <table id="tbCus" class="easyui-datagrid">
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
                <th field="Actions" width="75">
                    操作
                </th>
            </tr>
        </thead>
    </table>
    
    <!--新增、编辑框-->
    <div id="dlg" class="easyui-dialog" style="width: 780px; height: 580px; padding: 10px 15px"
        closed="true" buttons="#dlg-buttons">
        <div class="ftitle">
            客户基本信息</div>
        <form id="fm" method="post" novalidate>           
        <table cellpadding="5">
            <tr>
                <td style="text-align:right;">客户编号:</td>
                <td  colspan="2"> <input name="firstname" class="easyui-validatebox input-w7" required="true" /></td>
                <td style="text-align:right;">建档日期:</td>
                <td  colspan="2"><input class="easyui-datebox textbox input-w7" /></td>
            </tr>
            <tr>
                <td style="text-align:right;">客户全称:</td>
                <td  colspan="2"><input name="lastname" class="easyui-validatebox input-w7" required="true" /></td>
                <td style="text-align:right;">客户简称:</td>
                <td  colspan="2"><input name="lastname" class="easyui-validatebox input-w7" required="true" /></td>
            </tr>
            <tr>
                <td style="text-align:right;">客户类别:</td>
                <td  colspan="2">
                    <select class="easyui-combobox input-w7" name="language">
                <option value="ar">类别1</option>
                <option value="bg">类别2</option>
                <option value="ca">类别3</option>
                <option value="zh-cht">类别4</option>
            </select>
                </td>
                <td style="text-align:right;">经办人员:</td>
                <td  colspan="2"><input name="phone" class="input-w7" /></td>
            </tr>
            <tr>
                <td style="text-align:right;">公司地址:</td>
                <td  colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email"></td>
                <td style="text-align:right;">电话:</td>
                <td  colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email"></td>
            </tr>
            <tr>
                <td style="text-align:right;">开户银行:</td>
                <td  colspan="2"><select class="easyui-combobox input-w7" name="fapiao">
                <option value="ar">中国银行</option>
                <option value="bg">招商银行</option>
                <option value="ca">中信银行</option>
                <option value="zh-cht">建设银行</option>
            </select></td>
                <td style="text-align:right;">发票类型:</td>
                <td  colspan="2">
                     <select class="easyui-combobox input-w7" name="fapiao">
                <option value="ar">类型1</option>
                <option value="bg">类型2</option>
                <option value="ca">类型3</option>
                <option value="zh-cht">类型4</option>
            </select>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"> 营业执照码:</td>
                <td  colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email">    </td>
                <td style="text-align:right;"> 帐号:</td>
                <td  colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email"></td>
            </tr>
            <tr>
                <td style="text-align:right;">电话:</td>
                <td colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email"></td>
                <td style="text-align:right;">地址:</td>
                <td colspan="2"><input name="email" class="easyui-validatebox input-w7" validtype="email"></td>
            </tr>
            <tr>
                <td style="text-align:right;">开票全称:</td>
                <td colspan="5"> <input name="email" class="easyui-validatebox input-w12" validtype="email"></td>                
            </tr>
            <tr>
                <td style="text-align:right;">税务登记:</td>
                <td colspan="5"><input name="email" class="easyui-validatebox input-w12" validtype="email"></td>                
            </tr>
            <tr>
                <td style="text-align:right;"> 联系人1:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
                <td style="text-align:right;">职务:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
                <td style="text-align:right;">电话:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
            </tr>
            <tr>
                 <td style="text-align:right;"> 联系人2:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
                <td style="text-align:right;">职务:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
                <td style="text-align:right;">电话:</td>
                <td><input name="email" class="easyui-validatebox input-w5" validtype="email"></td>
            </tr>
        </table>           
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
            $('#tbCus').datagrid({
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
        });

        function checkUser(Id) {
            alert("查看" + Id);
        }


        function newUser() {
            $('#dlg').dialog('open').dialog('setTitle', '新增客户');
            $('#fm').form('clear');
            url = 'save_user.php';
        }
        function editUser() {
            var row = $('#tbCus').datagrid('getSelected');
            if (row) {
                $('#dlg').dialog('open').dialog('setTitle', '编辑客户');
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
                        $('#tbCus').datagrid('reload');    // reload the user data
                    }
                }
            });
        }
        function destroyUser() {
            var row = $('#tbCus').datagrid('getSelected');
            if (row) {
                $.messager.confirm('Confirm', 'Are you sure you want to destroy this user?', function (r) {
                    if (r) {
                        $.post('destroy_user.php', { id: row.id }, function (result) {
                            if (result.success) {
                                $('#tbCus').datagrid('reload');    // reload the user data
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
