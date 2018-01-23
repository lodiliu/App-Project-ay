<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADT.XingZhi.FineManage._Default" %>

<!DOCTYPE html>

<html>
<head>
    <title>星知艺人管理平台登录页面</title>
    <style type="text/css">
    .body_bj{background:#d3d3d3 url(/res/images/login/body_bj.png) no-repeat center top;}
    #login_wrap{font:12px/20px 'Simsun';color:#222;padding-top:300px;position:relative;}
    #login_wrap .fl{width:224px;height:40px;margin-top:26px;background:url(/res/images/logo.png) no-repeat 0 0;position:absolute;left:50%;margin-left:-254px;}
    #login_wrap .fr{width:240px;height:160px;position:absolute;right:50%;margin-right:-254px;}
    #login_wrap .fr div{display:block;height:36px;}
    #login_wrap .fr div.last_btn{padding-left:4em;}
    #login_wrap .fr div.last_btn input{border:none;font:16px/30px "Microsoft Yahei";background:url(/res/images/login/btn_submit.png) no-repeat 0 0;width:70px;height:30px;color:#fff; cursor:pointer;}
    #login_wrap .fr div input{color:#000;}
    .u_name,.u_pwd{background:url(/res/images/login/ipt_txt_bj.png) no-repeat left 0;height:19px;border:solid 1px #cacaca;width:154px;font:12px/19px 'Simsun';color:#444;padding:2px 3px;}
    #login_wrap .cop_box{position:relative;top:210px; text-align:center;display:block;width:100%;color:#999;}
    #login_wrap .cop_box em{font-weight:normal;}
    </style>
    <script type="text/javascript">
        if (top.window != window) {
            top.window.location.href = "/default.aspx";
        }
    </script>
</head>
<body class="body_bj">
<div id="login_wrap">
	<h1 class="fl"></h1>
	<div class="fr">
        <form action="Default.aspx?action=login" method="post">
			<div>用户名：<input class="u_name" id="username" name="username" type="text" /></div>
			<div>密&nbsp;&nbsp;码：<input class="u_pwd" id="userpwd" name="userpwd" type="password" /></div>
			<div class="last_btn"><input class="btn_sjrz" type="submit" value="登录" onclick="return login();" /></div>
        </form>
	</div>
	<strong class="cop_box">版权所有：<em>ADT.XingZhi</em>&nbsp;&nbsp;技术支持：<em>上海艾艺信息技术有限公司</em></strong>
</div>
<script src="/res/editor/third-party/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function login() {
        var $name = $.trim($("#username").val());
        var $pwd = $.trim($("#userpwd").val());
        if ($name == "") {
            alert('请输入用户名!');
            $("#username").focus();
            return false;
        }
        if ($pwd == "") {
            alert('请输入密码!');
            $("#password").focus();
            return false;
        }
        return true;
    }
</script> 
</body>
</html>