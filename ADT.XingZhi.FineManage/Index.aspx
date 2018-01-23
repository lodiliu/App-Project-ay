<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ADT.XingZhi.FineManage.Index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>星知艺人管理系统首页</title>
    <style type="text/css">
        em {
            font-style: normal;
        }

        ul, ol, li {
            list-style: none;
        }

        a {
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        .white, .white a {
            color: #fff;
        }

        .cut_line span {
            color: #367abb;
            padding: 0 4px;
        }

        .lf {
            float: left;
        }

        .text-c {
            text-align: center;
        }

        .text-r {
            text-align: right;
        }

        .invisible {
            visibility: hidden;
        }

        .header {
            background: #3c86c5 url(/res/images/index/h_bg.gif) no-repeat right top;
            height: 80px;
            position: relative;
        }

            .header .logo {
                float: left;
                width: 160px;
                height: 60px;
                margin-top: 20px;
                margin-right: 10px;
                _margin-right: 7px;
                background: url(/res/images/logo.png) no-repeat;
            }

                .header .logo a {
                    display: block;
                    height: 80px;
                    text-decoration: none;
                }

            .header .rt-col {
                position: absolute;
                top: 0px;
                right: 0px;
                width: 280px;
                height: 44px;
                z-index: 10;
            }

            .header .nav {
                display: block;
                height: 34px;
                position: relative;
                bottom: -10px;
            }

            .header .col-auto {
                overflow: visible;
                float: none;
            }

            .header .nav li, .header .nav li a {
                background: url(/res/images/index/nav_bg.png) no-repeat;
                display: block;
                _float: left;
                height: 34px;
                line-height: 38px;
                font-size: 14px;
                font-weight: 700;
            }

            .header .nav li {
                float: left;
                padding: 0 0 0 8px;
            }

                .header .nav li a {
                    background-position: right top;
                    padding: 0 15px 0 7px;
                }

                .header .nav li.on {
                    background-position: left -43px;
                }

                    .header .nav li.on a {
                        background-position: right -43px;
                        color: #367abb;
                    }

            .header .col-auto {
                height: 80px;
            }

            .header .log {
                padding: 16px 0 0 10px;
                height: 20px;
            }

            .header .tab_style {
                padding: 16px 14px 0 0 !important;
            }

        .fs10 {
            font-size: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" />
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server" AutoScroll="True">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="80px" ShowHeader="false" RegionPosition="Top"
                    Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ID="ContentPanel1" ShowBorder="false" CssClass="header" ShowHeader="false" runat="server">
                            <div class="header">
                                <div class="logo lf"><a href="http://www.adinnet.cn" target="_blank"><span class="invisible">CMS内容管理系统</span></a></div>
                                <div class="rt-col">
                                    <div class="tab_style white cut_line text-r">
                                        <a href="###">帮助？</a>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <div class="log white cut_line">
                                        您好！<% =userName %>  [<% =ip %>]<span>|</span>[<em id="currentTime"></em>]<span>|</span><a href="?action=logout">[退出]</a>
                                    </div>
                                    <ul class="nav white">
                                        <% =menu.ToString() %>
                                    </ul>
                                </div>
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" RegionSplit="true" Width="160px" ShowHeader="false"
                    EnableCollapse="true" EnableIFrame="true" IFrameName="leftframe" EnableAjax="false" Layout="Fit" RegionPosition="Left" runat="server" IFrameUrl="about:blank">
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" RegionPosition="Center" EnableIFrame="true"
                    IFrameName="mainframe" IFrameUrl="about:blank" runat="server">
                </f:Region>
                <f:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <f:ContentPanel ID="ContentPanel2" runat="server" ShowBorder="false" ShowHeader="false">
                            <div class="lf fs10">版本：V1.0</div>
                            <div class="text-c fs10">Copyright &copy; 2015 上海艾艺信息技术有限公司 版权所有</div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
    </form>
    <script src="/res/editor/third-party/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //设置当前时间
        function setCurrentTime() {
            var currTime = document.getElementById("currentTime")
            var today = new Date();
            year = today.getFullYear().toString();
            month = today.getMonth() + 1;
            date = today.getDate();
            hour = today.getHours();
            minute = today.getMinutes();
            second = today.getSeconds();
            currTime.innerHTML = '当前时间：' + year + '-' + month + '-' + date + ' ' + hour + ':' + minute + ':' + second;
        }
        // 当前时间并定时更新
        setCurrentTime();
        window.setInterval(setCurrentTime, 1000);
        F.ready(function () {
            var menuLis = $('.col-auto ul li');
            menuLis.click(function (e) {
                var $this = $(this);
                var classNames = /menu\-(\w+)/.exec($this.attr('class'));
                if (classNames.length == 2) {
                    var menuType = classNames[1];

                    menuLis.removeClass('on');
                    $this.addClass('on');

                    window.frames['leftframe'].location.href = '/leftmenu.aspx?menu=' + menuType;
                }
            });
        });
    </script>
</body>
</html>
