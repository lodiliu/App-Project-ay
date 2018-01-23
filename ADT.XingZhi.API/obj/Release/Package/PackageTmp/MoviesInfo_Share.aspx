<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoviesInfo_Share.aspx.cs" Inherits="ADT.XingZhi.API.MoviesInfo_Share" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!-- 
	开发人员书写规范:
	1.所有缩进都用 TAB 长度4， 而不是空格。
	2.非必要，禁止用行内样式例如 <div style="display:block"> 
 -->
    <meta charset="utf-8" />
    <script src="js/lib/browser.js"></script>
    <!--浏览器判断-->
    <script src="js/app/jay.js"></script>
    <title>详情</title>
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
            var qs = location.search.substr(1).split('&');
            var userid = "";
            var titleid = "";
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
                url: "API/GetFindPlay/GetFindPlayByTitle?titleid=" + titleid,
                success: function (data) {
                    $("#LoadInfo").append(data);
                },
                error: function (data) {
                    alert(data.statusText);
                }
            });
            $.ajax({
                type: "get",
                dataType: "json",
                url: "API/GetFindPlay/GetFindPlayByHotComment?userid=" + userid + "&titleid=" + titleid,
                success: function (data) {
                    $("#LoadComment").append(data);
                },
                error: function (data) {
                    alert(data.statusText);
                }
            });
        }

    </script>
</head>
<body>
    <!-- 影视剧组讯详情列表 -->
    <div class="container">
        <ul class="rn-media-list" id="LoadInfo">
        </ul>
        <div class="hot-comment-title pxLine">
            热门评论
        </div>
        <ul class="comment-list" id="LoadComment">
        </ul>
        <!-- 下载 start -->
        <div class="ranking-footer">
            <img src="images/logo.png" alt="" />
            <ul>
                <li>星知App</li>
                <li>去App store下载</li>
            </ul>
            <a href="#" class="downloadTxt">立即下载</a>
        </div>
        <!-- 下载 end -->
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
