<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TitleIndex
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div position="left" title="主要菜单" id="accordion1">
        <div title="功能列表" class="l-scroll">
            <ul id="tree1" style="margin-top: 3px;">
        </div>
        <div title="应用场景">
            <div style="height: 7px;">
            </div>
            <a class="l-link" href="javascript:f_addTab('listpage','列表页面','demos/case/listpage.htm')">
                列表页面</a> <a class="l-link" href="#" target="_blank">模拟Window桌面</a>
        </div>
        <div title="实验室">
            <div style="height: 7px;">
            </div>
            <a class="l-link" href="#" target="_blank">表格表单设计器</a>
        </div>
    </div>
    <div position="center" id="framecenter">
        <div tabid="home" title="我的主页" style="height: 300px">
            <iframe frameborder="0" name="home" id="home" src=""></iframe>
        </div>
    </div>
    
    <link href="../../Content/master.css" type="text/css" rel="stylesheet" />
    <script src="<%: Url.Content("http://www.zhi86.com/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("http://www.zhi86.com/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {
            $("#home").attr("src", "welcome.htm");
            //布局
            $("#layout1").ligerLayout({ leftWidth: 190, height: '100%', heightDiff: -34, space: 4, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //面板
            $("#accordion1").ligerAccordion({ height: height - 24, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });


            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#accordion1").ligerGetAccordionManager();
            tree = $("#tree1").ligerGetTreeManager();
            $("#pageloading").hide();

        });
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        function f_addTab(tabid, text, url) {
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        } 
             
            
    </script>
</asp:Content>
