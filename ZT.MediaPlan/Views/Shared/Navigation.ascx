<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ZT.MediaPlan.Logics" %>
<%@ Import Namespace="ZT.MediaPlan.Models" %>


<%
    IList<NavNodeInfo> listNodes = Navigation.GetUserNavNodes(34);
    foreach (NavNodeInfo n in listNodes)
    {
        Response.Write(string.Format("<div title=\"{0}\">", n.Text));
        Response.Write("<div style=\"height: 7px;\"></div>");
        foreach (NavNodeInfo c in n.ChildNodes)
        {
            Response.Write(string.Format("<a class=\"l-link\" href=\"javascript:f_addTab('{0}','{1}','{2}')\">{1}</a>", c.TabId, c.Text, c.Src));
        }
        Response.Write("</div>");
    }
     %>

<script type="text/javascript">
    var tab = null;
    var accordion = null;    
    var tabItems = [];
    $(function () {
        $(".l-link").hover(function () {
            $(this).addClass("l-link-over");
        }, function () {
            $(this).removeClass("l-link-over");
        });               
    });

    function f_addTab(tabid, text, url) {
        tab.addTabItem({
            tabid: tabid,
            text: text,
            url: url,
            callback: function () {
                addFrameSkinLink(tabid);
            }
        });
    }
    function addFrameSkinLink(tabid) {
        var prevHref = getLinkPrevHref(tabid) || "";
        var skin = getQueryString("skin");
        if (!skin) return;
        skin = skin.toLowerCase();
        attachLinkToFrame(tabid, prevHref + skin_links[skin]);
    }

    function getQueryString(name) {
        var now_url = document.location.search.slice(1), q_array = now_url.split('&');
        for (var i = 0; i < q_array.length; i++) {
            var v_array = q_array[i].split('=');
            if (v_array[0] == name) {
                return v_array[1];
            }
        }
        return false;
    }
    function attachLinkToFrame(iframeId, filename) {
        if (!window.frames[iframeId]) return;
        var head = window.frames[iframeId].document.getElementsByTagName('head').item(0);
        var fileref = window.frames[iframeId].document.createElement("link");
        if (!fileref) return;
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", filename);
        head.appendChild(fileref);
    }
    function getLinkPrevHref(iframeId) {
        if (!window.frames[iframeId]) return;
        var head = window.frames[iframeId].document.getElementsByTagName('head').item(0);
        var links = $("link:first", head);
        for (var i = 0; links[i]; i++) {
            var href = $(links[i]).attr("href");
            if (href && href.toLowerCase().indexOf("ligerui") > 0) {
                return href.substring(0, href.toLowerCase().indexOf("lib"));
            }
        }
    }
</script>
