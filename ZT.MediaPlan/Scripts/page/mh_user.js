//用户管理模块

//获取用户基本信息，以JSON的方式
function GetUserJson() {
    var json = new Object();
    json.UserId = remCommas($("#UserId").val());
    json.UserName = $("#UserName").val();
    json.EngName = $("#EngName").val();
    json.Sex = $("#Sex").combobox('getValue');
    json.Age = $("#Age").val();
    json.PhoneNumber = $("#PhoneNumber").val();
    json.Birthday = $("#Birthday").datebox('getValue');
    json.ICNumber = $("#ICNumber").val();
    json.Address = $("#Address").val();
    json.JobTitle = $("#JobTitle").combobox('getValue');
    json.DeptId = $("#Department").combobox('getValue');
    json.Email = $("#Email").val();
    json.TaxNumber = $("#TaxNumber").val();
    json.ParentId = $("#DirectUser").combobox('getValue');
    json.JoinDate = $("#JoinDate").datebox('getValue');

    return json;
}

//获取用户登录
function GetMemberJson() {
    var json = new Object();
    json.LoginName = $("#LoginName").val();
    json.Password = $("#Password").val();

    return json;
}