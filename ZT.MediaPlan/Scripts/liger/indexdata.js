var indexdata = 
[
    { text: '基础',isexpand:false, children: [ 
		{url:"demos/base/resizable.htm",text:"改变大小"},
		{url:"demos/base/drag.htm",text:"拖动"},
		{url:"demos/base/drag2.htm",text:"拖动2"},
		{url:"demos/base/dragresizable.htm",text:"拖动并改变大小"},
		{url:"demos/base/tip.htm",text:"气泡"},
		{ url: "demos/base/tip2.htm", text: "气泡2" },
        { url: "System/EditPassword", text: "修改密码" },
        { url: "Users/List", text: "用户管理" },
        { url: "Roles/List", text: "角色管理" },
        { url: "Actions/List", text: "动作管理" }
	]
    },
    { text: '过滤器', isexpand: false, children: [
		{ url: "demos/filter/filter.htm", text: "自定义查询" },
		{ url: "demos/filter/filterwin.htm", text: "在窗口显示" },
		{ url: "demos/filter/grid.htm", text: "配合表格" } 
	]
    }, 
	{ text: '弹窗',isexpand:false, children: [ 
		{ url: "demos/dialog/dialogAll.htm", text: "弹出框" },
        { url: "demos/dialog/dialogParent.htm", text: "子窗口传参" },
		{url:"demos/dialog/dialogTarget.htm",text:"载入目标DIV"},
		{url:"demos/dialog/dialogUrl.htm",text:"窗口"}, 
		{url:"demos/dialog/tip.htm",text:"右下角的提示"}, 
		{url:"demos/dialog/window.htm",text:"可最小化"}
	]},
	{ text: '菜单',isexpand:false, children: [  
		{url:"demos/menu/evenmenu.htm",text:"事件支持"},
		{url:"demos/menu/menubar.htm",text:"菜单条/工具条"}, 
		{url:"demos/menu/mulmenu.htm",text:"多个菜单同时存在"}
	]},		
    {
        text: "ListBox", isexpand: "false", children: [
            { url: "demos/listbox/listboxCheckbox.htm", text: "显示复选框" },
            { url: "demos/listbox/listboxMove.htm", text: "列表框可移动" },
            { url: "demos/listbox/listboxMul.htm", text: "多选列表框" },
            { url: "demos/listbox/listboxSingle.htm", text: "单选列表框" },
            { url: "demos/listbox/listboxTable.htm", text: "表格列表框" }
        ]
    }  
];


var indexdata2 =
[
    { isexpand: "true", text: "表格", children: [
        { isexpand: "true", text: "可排序", children: [
		    { url: "dotnetdemos/grid/sortable/client.aspx", text: "客户端" },
            { url: "dotnetdemos/grid/sortable/server.aspx", text: "服务器" }
	    ]
        },
        { isexpand: "true", text: "可分页", children: [
		    { url: "dotnetdemos/grid/pager/client.aspx", text: "客户端" },
            { url: "dotnetdemos/grid/pager/server.aspx", text: "服务器" }
	    ]
        },
        { isexpand: "true", text: "树表格", children: [
		    { url: "dotnetdemos/grid/treegrid/tree.aspx", text: "树表格" }, 
		    { url: "dotnetdemos/grid/treegrid/tree2.aspx", text: "树表格2" }
	    ]
        }
    ]
    }
];
