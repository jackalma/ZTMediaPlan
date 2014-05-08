//客户管理模块

//获取客户信息，以JSON的方式
function GetCustomerJson() {
    var json = new Object();
    //排期编号
    json.seqId = remCommas($("#seqId").text());

    //排期类型 0:挑媒体 1:RON 3:混排
    json.planType = $("input[name='planType']:checked").val();

    //提案信息
    json.proposalId = $("#proposalId").val();
    json.customerId = $("#customerID").val();
    json.customerName = $("#customerText").val();
}