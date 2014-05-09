//客户管理模块

//获取客户信息，以JSON的方式
function GetCustomerJson() {
    var json = new Object();
    json.CustomerNo = $("#CustomerNo").val();
    json.CreateTime = $("#CreateTime").datebox('getValue'); //获取时间
    json.FullName = $("#FullName").val();
    json.ShortName = $("#ShortName").val();
    json.CustomerType = $("#CustomerType").combobox('getValue');
    json.Creator = $("#Creator").val();
    json.CompanyAddress = $("#CompanyAddress").val();
    json.CompanyTel = $("#CompanyTel").val();
    json.BusinessLicNo = $("#BusinessLicNo").val();
    json.ReceiptType = $("#ReceiptType").combobox('getValue');
    json.OpenBank = $("#OpenBank").combobox('getValue');
    json.AccountNo = $("#AccountNo").val();
    json.BankTel = $("#BankTel").val();
    json.BankAddress = $("#BankAddress").val();
    json.BRFullName = $("#BRFullName").val();
    json.TaxNo = $("#TaxNo").val();
    json.Contacter_A = $("#Contacter_A").val();
    json.Position_A = $("#Position_A").val();
    json.Tel_A = $("#Tel_A").val();
    json.Contacter_B = $("#Contacter_B").val();
    json.Position_B = $("#Position_B").val();
    json.Tel_B = $("#Tel_B").val();

    return json;
}