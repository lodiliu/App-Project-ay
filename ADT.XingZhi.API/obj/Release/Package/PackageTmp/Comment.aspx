<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="ADT.XingZhi.API.Comment" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html xmlns="CAP">
<head runat="server">
    <!-- 
	开发人员书写规范:
	1.所有缩进都用 TAB 长度4， 而不是空格。
	2.非必要，禁止用行内样式例如 <div style="display:block"> 
 -->
    <meta charset="utf-8" />
    <script src="js/lib/browser.js"></script>

    <title>TITLE</title>
    <meta name="description" content="" />
    <meta name="author" content="J.Chen" />
    <!-- IOS6全屏 Chrome高版本全屏 -->
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="mobile-web-app-capable" content="yes" />
    <!-- Mobile Specific Metas -->
    <!-- !!!注意 minimal-ui 是IOS7.1的新属性，最小化浏览器UI，但是在 iOS8.1 被取消 -->
    <!--Safari 将会对有内容溢出 Viewport 区域的页面进行缩放适配，使溢出的内容完整展示而不出现滚动条，而在 Viewport 设置中引入了一个新属性 shrink-to-fit = no，该属性可以禁止这种缩放行为的发生。-->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0, shrink-to-fit=no" />
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <!-- Enable iOS 自动检测电话号码 -->
    <meta name="format-detection" content="telephone=yes" />
    <!-- 禁止百度转码 -->
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <!-- 针对手持设备优化  -->
    <!-- QQ强制竖屏 -->
    <meta name="x5-orientation" content="portrait" />
    <!--or landscape-->
    <!-- QQ强制全屏 -->
    <meta name="x5-fullscreen" content="true" />
    <!-- QQ应用模式 -->
    <meta name="x5-page-mode" content="app" />
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/common.js"></script>
    <script type="text/javascript">

        $(function () {
            PageLoad();
        });

        function PageLoad() {
            //获取li的个数
            var liLength = document.getElementById("CommentList").getElementsByTagName('li').length;
            var qs = location.search.substr(1).split('&');
            var userid = "";
            var titleid = "";
            var pagesize = 5;
            var pageindex = 1;
            if (qs) {
                for (var i = 0; i < qs.length; i++) {
                    if (qs[i].substring(0, qs[i].indexOf('=')) == "userid") {
                        userid = qs[i].substring(qs[i].indexOf('=') + 1);
                        $("#hid_userid").val(userid);//userid赋值
                    }
                    else if (qs[i].substring(0, qs[i].indexOf('=')) == "titleid") {
                        titleid = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                }
            }
            $.ajax({
                type: "get",
                dataType: "json",
                url: "API/GetFindPlay/GetFindPlayByComment?userid=" + userid + "&titleid=" + titleid + "&pagesize=" + pagesize + "&pageindex=" + pageindex,
                success: function (data) {
                    $("#CommentList").append(data);
                    //获取总行数
                    var totallines = $(".pxLine").attr("data-id");
                    //获取已有的页数
                    var haslines = document.getElementById("CommentList").getElementsByTagName('li').length
                    if (totallines > haslines) {
                        document.getElementById("loadmore").style.display = "inline";
                        return;
                    }
                },
                error: function (data) {
                    alert(data.statusText);
                }
            });
        }

        function LoadMore() {
            //获取li的个数
            var liLength = document.getElementById("CommentList").getElementsByTagName('li').length;
            var qs = location.search.substr(1).split('&');
            var userid = "";
            var titleid = "";
            var pagesize = 5;
            if (qs) {
                for (var i = 0; i < qs.length; i++) {
                    if (qs[i].substring(0, qs[i].indexOf('=')) == "userid") {
                        userid = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                    else if (qs[i].substring(0, qs[i].indexOf('=')) == "titleid") {
                        titleid = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                }
            }
            var pages = 1 + parseInt(liLength / pagesize);
            $.ajax({
                type: "get",
                dataType: "json",
                url: "API/GetFindPlay/GetFindPlayByComment?userid=" + userid + "&titleid=" + titleid + "&pagesize=" + pagesize + "&pageindex=" + pages,
                success: function (data) {
                    $("#CommentList").append(data);
                    //获取总行数
                    var totallines = $(".pxLine").attr("data-id");
                    //获取已有的页数
                    var haslines = document.getElementById("CommentList").getElementsByTagName('li').length
                    if (totallines > haslines) {
                        document.getElementById("loadmore").style.display = "inline";
                        return;
                    }
                    else {
                        document.getElementById("loadmore").style.display = "none";
                    }
                },
                error: function (data) {
                    alert(data.statusText);
                }
            });
        }
    </script>
    <!--浏览器判断-->
    <script src="js/app/jay.js"></script>
</head>
<body>
    <cap
    <!-- 评论 -->
    <div class="container">
        <ul class="comment-list" id="CommentList">
        </ul>
        <div class="loadmore" id="loadmore" style="display: none">
            <div class="trigger_button">
                <div class="highlight"></div>
                <div class="highlightb"></div>
            </div>
        </div>
    </div>

    <!-- 提示框 start -->
    <div id="hbg" style="display: none;"></div>
    <div id="alertM" style="display: none;">
        <p id="alertP">请先登录！</p>
        <div id="alertBtns">
            <a id="alertY" title="关闭" onclick="closeTip()">关闭</a>
        </div>
    </div>
    <!-- 提示框 end -->
    <!-- 隐藏的userid start -->
    <input id="hid_userid" hidden="hidden" />
    <!-- 隐藏的userid end -->
</body>

</html>
