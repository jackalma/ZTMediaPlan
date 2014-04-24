<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div title="功能列表" class="l-scroll">
    <ul id="tree1" style="margin-top: 3px;">
    </ul>
</div>
<div title="系统管理">
    <div style="height: 7px;">
    </div>
    <a class="l-link" href="#" target="_blank">修改密码</a> <a class="l-link" href="#" target="_blank">
        用户管理</a> <a class="l-link" href="#" target="_blank">角色管理</a> <a class="l-link" href="#"
            target="_blank">动作管理</a>
</div>

<script type="text/javascript">
    var tab = null;
    var accordion = null;
    var tree = null;
    var tabItems = [];
    $(function () {
        $(".l-link").hover(function () {
            $(this).addClass("l-link-over");
        }, function () {
            $(this).removeClass("l-link-over");
        });
        //树
        $("#tree1").ligerTree({
            data: indexdata,
            checkbox: false,
            slide: false,
            nodeWidth: 120,
            attribute: ['nodename', 'url'],
            onSelect: function (node) {
                if (!node.data.url) return;
                var tabid = $(node.target).attr("tabid");
                if (!tabid) {
                    tabid = new Date().getTime();
                    $(node.target).attr("tabid", tabid)
                }
                f_addTab(tabid, node.data.text, node.data.url);
            }
        });

        tree = liger.get("tree1");
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
