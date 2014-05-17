<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>用户管理</title>
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/easyui/demo/demo.css" />
    <link rel="Stylesheet" type="text/css" href="../../Scripts/easyui/themes/ztsty.css" />
    <script type="text/javascript" src="../../Scripts/easyui/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="../../Scripts/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Scripts/page/mh_user.js"></script>
    <script type="text/javascript" src="../../Scripts/easyui/extendValid.js"></script>
    <script type="text/javascript" src="../../Scripts/JsonSerialize.js"></script>
    <script type="text/javascript" src="../../Scripts/common.js"></script>
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
            text-align: right;
            margin-left: 15px;
        }
    </style>
</head>
<body>
    <div>
        <table>
            <tr>
                <td>
                    部门:
                </td>
                <td>
                    <select id="selDept" name="selDept" class="easyui-combobox input-w7">
                    </select>
                </td>
                <td>
                    职位:
                </td>
                <td>
                    <select id="selJob" name="selJob" class="easyui-combobox input-w7">
                    </select>
                </td>
                <td>
                    状态:
                </td>
                <td>
                    <select id="selStatus" name="selStatus" class="easyui-combobox input-w7">
                    </select>
                </td>
            </tr>
        </table>
    </div>
    <table id="tbCus" class="easyui-datagrid">
        <thead>
            <tr>
                <th field="UserId" width="75">
                    用户编号
                </th>
                <th field="LoginName" width="175">
                    用户名
                </th>
                <th field="UserName" width="75">
                    姓名
                </th>
                <th field="EngName" width="180">
                    英文名
                </th>
                <th field="Sex" width="65">
                    性别
                </th>
                <th field="Department" width="90">
                    部门
                </th>
                <th field="JobTitle" width="100">
                    职位
                </th>
                <th field="DirectUser" width="130">
                    直接上级
                </th>
                <th field="JoinDate" width="110">
                    入职时间
                </th>
                <th field="LeaveDate" width="110">
                    离职时间
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
            录入用户信息</div>
        <form id="fm" method="post" novalidate>
        <fieldset style="padding: 13px; border-color: #95B8E7; border-width: 1px;
            border-style: solid">
            <legend>基本信息</legend>
             <table cellpadding="5" style="width:100%;">
                <tr>
                    <td style="text-align: right;">
                        用户编号:
                    </td>
                    <td colspan="5">
                        <input id="UserId" name="UserId" class="input-w7" readonly="readonly" required="true" />
                    </td>                   
                </tr>
                <tr>
                    <td style="text-align: right;">
                        中文名:
                    </td>
                    <td colspan="2">
                        <input id="UserName" name="UserName" class="easyui-validatebox input-w7" required="true" validType="maxLength[25]" />
                    </td>
                    <td style="text-align: right;">
                        英文名:
                    </td>
                    <td colspan="2">
                        <input id="EngName" name="EngName" class="easyui-validatebox input-w7"  validType="maxLength[15]" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        性别:
                    </td>
                    <td colspan="2">
                        <select id="Sex" name="Sex" class="easyui-combobox input-w7">
                            <option value="1">女</option>
                            <option value="2" selected="selected">男</option>
                        </select>
                    </td>
                    <td style="text-align: right;">
                        年龄:
                    </td>
                    <td colspan="2">
                        <input id="Age" name="Age" class="easyui-validatebox input-w7" validType="number" maxlength="10" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        手机号:
                    </td>
                    <td colspan="2">
                        <input id="PhoneNumber" name="PhoneNumber" class="easyui-validatebox input-w7" validType="number" maxlength="15" />
                    </td>
                    <td style="text-align: right;">
                        出生日期:
                    </td>
                    <td colspan="2">
                        <input id="Birthday" name="Birthday" class="easyui-datebox textbox input-w7" editable="false" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        身份证号:
                    </td>
                    <td colspan="2">
                        <input id="ICNumber" name="ICNumber" class="easyui-validatebox input-w7" validType="number" maxlength="25" />
                    </td>
                    <td style="text-align: right;">
                        家庭住址:
                    </td>
                    <td colspan="2">
                        <input id="Address" name="Address" class="easyui-validatebox input-w7" validType="maxLength[35]" />                        
                    </td>
                </tr>                                                                                          
            </table>
        </fieldset>
        
        <fieldset style="padding: 13px; margin-top:15px; border-color: #95B8E7; border-width: 1px;
            border-style: solid">
            <legend>职位信息</legend>
            <table cellpadding="5" style="width:100%;">
                <tr>
                    <td style="text-align: right;">
                        职位:
                    </td>
                    <td colspan="2">
                         <select id="JobTitle" name="JobTitle" class="easyui-combobox input-w7">
                        </select>
                    </td>
                    <td style="text-align: right;">
                        部门:
                    </td>
                    <td colspan="2">
                         <select id="Department" name="Department" class="easyui-combobox input-w7">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        邮箱:
                    </td>
                    <td colspan="2">
                        <input id="Email" name="Email" class="easyui-validatebox input-w7" required="true" validType="email" maxlength="25" />
                    </td>
                    <td style="text-align: right;">
                        座机号:
                    </td>
                    <td colspan="2">
                        <input id="TaxNumber" name="TaxNumber" class="easyui-validatebox input-w7" validType="maxLength[15]" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        直接上级:
                    </td>
                    <td colspan="2">                     
                        <input id="DirectUser" name="DirectUser" class="input-w7" required="true" />
                    </td>
                    <td style="text-align: right;">
                        入职日期:
                    </td>
                    <td colspan="2">
                        <input id="JoinDate" name="JoinDate" class="easyui-datebox textbox input-w7" required="true"
                            editable="false" />
                    </td>
                </tr>                                                                         
            </table>
        </fieldset>

      <fieldset style="padding: 13px; margin-top:15px; border-color: #95B8E7; border-width: 1px;
            border-style: solid">
            <legend>登录信息</legend>
            <table cellpadding="5" style="width:100%;">
                <tr>
                    <td style="text-align: right;">
                        用户名:
                    </td>
                    <td colspan="2">
                        <input id="LoginName" name="LoginName" class="easyui-validatebox input-w7" required="true" validType="vName" maxlength="15" />
                    </td>
                    <td style="text-align: right;">
                        初始密码:
                    </td>
                    <td colspan="2">
                        <input id="Password" name="Password" class="easyui-validatebox input-w7" required="true" validType="safepass" maxlength="15" />
                    </td>
                </tr>                                                                                                                                        
            </table>
        </fieldset>      
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
            InitUsersList();
            InitCustomerData();
        });

        //初始化用户列表
        function InitUsersList() {
            $('#tbCus').datagrid({
                title: '用户管理列表',
                iconCls: 'icon-edit', //图标  
                width: 700,
                height: 'auto',
                nowrap: false,
                striped: true,
                border: true,
                collapsible: false, //是否可折叠的  
                fit: true, //自动大小  
                url: '/Users/UserList',
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
                    text: '新增用户',
                    iconCls: 'icon-add',
                    handler: function () {
                        newUser();
                    }
                }, '-', {
                    text: '编辑用户',
                    iconCls: 'icon-edit',
                    handler: function () {
                        InitCreateData();
                        editUser();
                    }
                }, '-', {
                    text: '删除用户',
                    iconCls: 'icon-remove',
                    handler: function () {
                        destroyUser();
                    }
                }]
            });
        }

        //初始化加载数据
        function InitCustomerData() {
            //初始化查询条件
            //部门
            $('#selDept').combobox({
                url: '../../Config/dept.json',
                valueField: 'id',
                textField: 'value',
                method: 'get',
                onSelect: function () {
                    ReloadDG();
                }
            });           

            //职位
            $('#selJob').combobox({
                url: '../../Config/jobTitle.json',
                valueField: 'id',
                textField: 'value',
                method: 'get',
                onSelect: function () {
                    ReloadDG();
                }
            });          

            //状态
            $('#selStatus').combobox({
                url: '../../Config/accountStatus.json',
                valueField: 'id',
                textField: 'value',
                method: 'get',
                onSelect: function () {
                    ReloadDG();
                }
            });
        }

        //重新加载DataGrid
        function ReloadDG() {
            var queryParams = $('#tbCus').datagrid('options').queryParams;
            queryParams.deptId = $("#selDept").combobox('getValue');
            queryParams.jobTitle = $("#selJob").combobox('getValue');
            queryParams.status = $("#selStatus").combobox('getValue');
            //重新加载datagrid的数据  
            $("#tbCus").datagrid('reload');
        }

        //初始化创建用户数据
        function InitCreateData() {
            //部门
            $("#Department").combobox({
                url: '../../Config/dept.json',
                valueField: 'id',
                textField: 'value',
                method: 'get',
                onBeforeLoad: function (param) {

                }
            });

            //职位
            $("#JobTitle").combobox({
                url: '../../Config/jobTitle.json',
                valueField: 'id',
                textField: 'value',
                method: 'get',
                onBeforeLoad: function (param) {

                }
            });

            //直接上级
            $('#DirectUser').combogrid({
                panelWidth: 500,
                url: '/Users/GetDirectUser',
                idField: 'UserId',
                textField: 'UserName',
                mode: 'remote',
                fitColumns: true,
                columns: [[
                    { field: 'UserId', title: '编号', width: 60 },
                    { field: 'UserName', title: '姓名', width: 80 },
                    { field: 'Position', title: '职位', align: 'right', width: 60 },
                    { field: 'Department', title: '部门', align: 'right', width: 60 }                  
                ]]
            });          
        }

        function checkUser(Id) {
            alert("查看" + Id);
        }

        //新增用户
        function newUser() {
            $('#dlg').dialog('open').dialog('setTitle', '新增用户');
            $('#fm').form('clear');            

            $.ajax({
                url: '/Users/GetUserId',
                type: 'get',
                async: false,
                dataType: "json",
                success: function (value) {
                    if (value.num > 0)
                        $("#UserId").val(value.num);
                }
            });

            InitCreateData();
        }

        //编辑用户
        function editUser() {
            var row = $('#tbCus').datagrid('getSelected');
            if (row) {
                $('#dlg').dialog('open').dialog('setTitle', '编辑用户');              
                $('#fm').form('load', '/Users/GetUser?userId=' + row.UserId);
            }
        }

        //保存用户
        function saveUser() {
            var jsonBase = GetUserJson();
            var jsonLogin = GetMemberJson();

            $('#fm').form('submit', {
                url: '/Users/CreateUser?jsonBase=' + String.toSerialize(jsonBase) + '&jsonLogin=' + String.toSerialize(jsonLogin),
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

        //删除数据
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
