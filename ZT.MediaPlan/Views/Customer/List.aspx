<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>List</title>      
    <link href="../../Scripts/liger/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/liger/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/json2.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerTextBox.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerCheckBox.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerDateEditor.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/ligerUI/js/plugins/ligerSpinner.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/EmployeeData.js" type="text/javascript"></script>
    <script src="../../Scripts/liger/DepartmentData.js" type="text/javascript"></script>
    <script type="text/javascript">

        var DepartmentList = DepartmentData.Rows;
        var sexData = [{ Sex: 1, text: '男' }, { Sex: 2, text: '女'}];
        $(f_initGrid);
        var manager, g;
        function f_initGrid() {
            g = manager = $("#maingrid").ligerGrid({
                columns: [
                { display: '主键', name: 'ID', width: 50, type: 'int', frozen: true },
                { display: '名字', name: 'RealName',
                    editor: { type: 'text' }
                },
                { display: '性别', width: 50, name: 'Sex', type: 'int',
                    editor: { type: 'select', data: sexData, valueField: 'Sex' },
                    render: function (item) {
                        if (parseInt(item.Sex) == 1) return '男';
                        return '女';
                    }
                },
                { display: '年龄', name: 'Age', width: 50, type: 'int', editor: { type: 'int'} },
                { display: '操作', isSort: false, width: 120, render: function (rowdata, rowindex, value) {
                    var h = "";
                    if (!rowdata._editing) {
                        h += "<a href='javascript:beginEdit(" + rowindex + ")'>修改</a> ";
                        h += "<a href='javascript:deleteRow(" + rowindex + ")'>删除</a> ";
                    }
                    else {
                        h += "<a href='javascript:endEdit(" + rowindex + ")'>提交</a> ";
                        h += "<a href='javascript:cancelEdit(" + rowindex + ")'>取消</a> ";
                    }
                    return h;
                }
                }
                ],
                onSelectRow: function (rowdata, rowindex) {
                    $("#txtrowindex").val(rowindex);
                },
                enabledEdit: true, clickToEdit: false, isScroll: false,
                data: EmployeeData,
                width: '100%'
            });
        }
        function beginEdit(rowid) {
            manager.beginEdit(rowid);
        }
        function cancelEdit(rowid) {
            manager.cancelEdit(rowid);
        }
        function endEdit(rowid) {
            manager.endEdit(rowid);
        }

        function deleteRow(rowid) {
            if (confirm('确定删除?')) {
                manager.deleteRow(rowid);
            }
        }
        var newrowid = 100;
        function addNewRow() {
            manager.addEditRow();
        }

        function getSelected() {
            var row = manager.getSelectedRow();
            if (!row) { alert('请选择行'); return; }
            alert(JSON.stringify(row));
        }
        function getData() {
            var data = manager.getData();
            alert(JSON.stringify(data));
        } 
    </script>  
</head>
<body style="padding:10px">
    <div class="l-clear"></div>
    <div id="maingrid" style="margin-top:20px"></div> <br />
       <br />
   <a class="l-button" style="width:120px" onclick="getSelected()">获取选中的值(选择行)</a>
 
   <br />
   <a class="l-button" style="width:120px" onclick="getData()">获取当前的值</a>
  <div style="display:none;">
  <!-- g data total ttt -->
</div>
</body>
</html>
