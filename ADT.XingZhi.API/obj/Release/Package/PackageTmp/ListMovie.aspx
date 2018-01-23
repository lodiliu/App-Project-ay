<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMovie.aspx.cs" Inherits="ADT.XingZhi.API.ListMovie" %>

<!DOCTYPE html>
<html lang="zh-Hans">
<!--lang="zh-Hans" 代表 Chinese (Simplified)-->
<!--关于 html lang 标签的资料在这里找到: http://www.w3schools.com/tags/ref_language_codes.asp-->

<head>
    <!-- 
	开发人员书写规范:
	1.所有缩进都用 TAB 长度4， 而不是空格。
	2.非必要，禁止用行内样式例如 <div style="display:block"> 
 -->
    <meta charset="utf-8">
    <script src="js/lib/browser.js"></script>
    <!--浏览器判断-->
    <script src="js/app/jay.js"></script>
    <title>星知-电影榜单</title>
    <meta name="description" content="">
    <meta name="author" content="J.Chen">
    <!-- IOS6全屏 Chrome高版本全屏 -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="mobile-web-app-capable" content="yes">
    <!-- Mobile Specific Metas -->
    <!-- !!!注意 minimal-ui 是IOS7.1的新属性，最小化浏览器UI，但是在 iOS8.1 被取消 -->
    <!--Safari 将会对有内容溢出 Viewport 区域的页面进行缩放适配，使溢出的内容完整展示而不出现滚动条，而在 Viewport 设置中引入了一个新属性 shrink-to-fit = no，该属性可以禁止这种缩放行为的发生。-->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0, shrink-to-fit=no">
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <!-- Enable iOS 自动检测电话号码 -->
    <meta name="format-detection" content="telephone=yes">
    <!-- 禁止百度转码 -->
    <meta http-equiv="Cache-Control" content="no-siteapp">
    <!-- 针对手持设备优化  -->
    <!-- QQ强制竖屏 -->
    <meta name="x5-orientation" content="portrait">
    <!--or landscape-->
    <!-- QQ强制全屏 -->
    <meta name="x5-fullscreen" content="true">
    <!-- QQ应用模式 -->
    <meta name="x5-page-mode" content="app">
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(function readyReg() {
            //获取li的个数
            var liLength = document.getElementById("MovieList").getElementsByTagName('li').length;
            if (liLength == 100) {//因为只显示100行，所以判断
                document.getElementById("loadmore").style.display = "none";
                return;
            }
        });

        function LoadMore() {
            //获取li的个数
            var liLength = document.getElementById("MovieList").getElementsByTagName('li').length;
            var qs = location.search.substr(1).split('&');
            var type = "";
            var gender = "";
            var orderby = "";
            var pagesize = 0;
            if (qs) {
                for (var i = 0; i < qs.length; i++) {
                    if (qs[i].substring(0, qs[i].indexOf('=')) == "type") {
                        type = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                    else if (qs[i].substring(0, qs[i].indexOf('=')) == "gender") {
                        gender = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                    else if (qs[i].substring(0, qs[i].indexOf('=')) == "pagesize") {
                        pagesize = qs[i].substring(qs[i].indexOf('=') + 1);
                    }
                }
            }

            var pages = 1 + parseInt(liLength / pagesize);
            $.ajax({
                type: "get",
                dataType: "json",
                url: "API/GetList/GetListByMovie_Share?type=" + type + "&gender=" + gender + "&orderby=" + orderby + "&pagesize=" + pagesize + "&pageindex=" + pages + "&length=" + liLength,
                success: function (data) {
                    $("#MovieList").append(data);
                    //获取已有的页数
                    var haspages = document.getElementById("MovieList").getElementsByTagName('li').length
                    var floatpages = parseFloat(haspages / pagesize);
                    var intpages = parseInt(haspages / pagesize);
                    if (floatpages > intpages) {
                        document.getElementById("loadmore").style.display = "none";
                        return;
                    }
                },
                error: function (data) {
                    alert(data.statusText);
                }
            });
        }
    </script>
</head>

<body>
    <!-- 榜单 -->
    <div class="container">
        <div class="ranking-list-con">
            <ul class="ranking-list" id="MovieList">
                <%=LoadInfo() %>
            </ul>
            <div class="loadmore" id="loadmore">
                <div class="trigger_button">
                    <div class="highlight"></div>
                    <div class="highlightb"></div>
                </div>
            </div>
        </div>
        <div class="ranking-footer">
            <img src="images/logo.png" alt="">
            <ul>
                <li>星知App</li>
                <li>去App store下载</li>
            </ul>
            <a href="#" class="downloadTxt">立即下载</a>
        </div>
    </div>
</body>
</html>
