﻿$(function () {
 //   $('#content').html(" &nbsp; &nbsp; &nbsp;上海贯同体育文化产业发展有限公司，是一家从事体育营销和品牌推广的专业机构。公司以客户需求为导向，秉承先进的体育营销理念，整合各类社会资源，致力于为企业提供专业的体育营销咨询、赛事管理、品牌推广、活动策划执行及媒体整合传播等服务。&nbsp;<div>&nbsp; &nbsp; &nbsp;公司2015年5月成立 ，同时启动“运动报名”APP开发计划，计划10月底上线测试运营，运动报名集成68项运动比赛和培训的报名功能，面向全国的体育爱好者、培训机构和赛事团体，赛事公司和机构个人都可以通过APP发布活动或培训信息，参与运动报名的人可以形成一个运动圈，方便运动的参与者快速了解活动信息,参与报名，给活动和培训的发起者多了一个报名参与的渠道。</div><div>&nbsp; &nbsp; &nbsp;将运动和移动互联网结合在一起，打造个性便捷的运动报名APP。</div><div>&nbsp; &nbsp; &nbsp;这是一个充满智慧与激情的团队，我们奋力拼搏，积极进取，向更高更远的目标携手前进，相信坚持梦想，就能创造辉煌！欢迎热爱体育事业、有理想、有激情、有冲劲、有才华的你加入我们，一起学习，共同成长！</div>");

  
    $.ajax({
        type: "post",
        url: "/Handler/contact.ashx",
        async: false,//同步：意思是当有返回值以后才会进行后面的js程序。
        data: { },
        dataType: "json",
        success: function (data) {
            if (data.Success == true) {
                $('#content').html(data.Msg);
            }
            else {
                $('#content').html(data.Msg);
            }
        },
        error: function () {
            alert("信息获取失败！");
        }
    });

});