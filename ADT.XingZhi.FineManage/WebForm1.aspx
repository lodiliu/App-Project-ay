<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ADT.XingZhi.FineManage.WebForm1" %>

<%--  <html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        body, html {
            width: 100%;
            height: 100%;
            margin: 0;
            font-family: "微软雅黑";
        }

        #l-map {
            height: 300px;
            width: 100%;
        }

        #r-result {
            width: 100%;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ygeLq33hvHaNharLvlbGQHo8"></script>
  <title>本地搜索的结果面板</title>
</head>
<body>
    <div id="l-map"></div>
    <div id="r-result"></div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("l-map");            // 创建Map实例
    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
    var local = new BMap.LocalSearch(map, {
        renderOptions: { map: map, panel: "r-result" }
    });
    local.search("餐饮");
</script>--%>

<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ygeLq33hvHaNharLvlbGQHo8"></script>
	<title>地址解析</title>
</head>
<body>
	<div id="allmap"></div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("allmap");
    var point = new BMap.Point(116.331398, 39.897445);
    map.centerAndZoom(point, 12);
    // 创建地址解析器实例
    var myGeo = new BMap.Geocoder();
    // 将地址解析结果显示在地图上,并调整地图视野
    myGeo.getPoint("上海浦东新区浦东大道280号", function (point) {
        if (point) {
            map.centerAndZoom(point, 16);
            map.addOverlay(new BMap.Marker(point));
            var s = point.lng+';'+point.lat;
            alert(s);
        } else {
            alert("您选择地址没有解析到结果!");
        }
    }, "北京市");
</script>
