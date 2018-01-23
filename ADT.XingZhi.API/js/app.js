
function connectWebViewJavascriptBridge(callback) {
    if (window.WebViewJavascriptBridge) {
        callback(WebViewJavascriptBridge)
    } else {
        document.addEventListener('WebViewJavascriptBridgeReady', function () {
            callback(WebViewJavascriptBridge)
        }, false)
    }
}
var taozhuan = false;

function openNewPage(url, titleid) {
    if (typeof (Android) != "undefined") {
        Android.jsGetTitleIdFunction(url, titleid);
        taozhuan = false;
    } else {
        connectWebViewJavascriptBridge(function (bridge) {
            var data = { 'url': url, 'titleid': titleid }
            taozhuan = false;
            bridge.send(data, function (responseData) {
                //log('JS got response', responseData)
            })
        })
    }
    if (taozhuan)
        location.href = url;
}

function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}

// 字符串转换utf-8  
function EncodeUtf8(s1) {
    // escape函数用于对除英文字母外的字符进行编码。如“Visit W3School!”->"Visit%20W3School%21"  
    var s = escape(s1);
    var sa = s.split("%");//sa[1]=u6211  
    var retV = "";
    if (sa[0] != "") {
        retV = sa[0];
    }
    for (var i = 1; i < sa.length; i++) {
        if (sa[i].substring(0, 1) == "u") {
            retV += Hex2Utf8(Str2Hex(sa[i].substring(1, 5)));
            if (sa[i].length >= 6) {
                retV += sa[i].substring(5);
            }
        }
        else retV += "%" + sa[i];
    }
    return retV;
}
function Str2Hex(s) {
    var c = "";
    var n;
    var ss = "0123456789ABCDEF";
    var digS = "";
    for (var i = 0; i < s.length; i++) {
        c = s.charAt(i);
        n = ss.indexOf(c);
        digS += Dec2Dig(eval(n));

    }
    //return value;  
    return digS;
}
function Dec2Dig(n1) {
    var s = "";
    var n2 = 0;
    for (var i = 0; i < 4; i++) {
        n2 = Math.pow(2, 3 - i);
        if (n1 >= n2) {
            s += '1';
            n1 = n1 - n2;
        }
        else
            s += '0';

    }
    return s;

}
function Dig2Dec(s) {
    var retV = 0;
    if (s.length == 4) {
        for (var i = 0; i < 4; i++) {
            retV += eval(s.charAt(i)) * Math.pow(2, 3 - i);
        }
        return retV;
    }
    return -1;
}
function Hex2Utf8(s) {
    var retS = "";
    var tempS = "";
    var ss = "";
    if (s.length == 16) {
        tempS = "1110" + s.substring(0, 4);
        tempS += "10" + s.substring(4, 10);
        tempS += "10" + s.substring(10, 16);
        var sss = "0123456789ABCDEF";
        for (var i = 0; i < 3; i++) {
            retS += "%";
            ss = tempS.substring(i * 8, (eval(i) + 1) * 8);



            retS += sss.charAt(Dig2Dec(ss.substring(0, 4)));
            retS += sss.charAt(Dig2Dec(ss.substring(4, 8)));
        }
        return retS;
    }
    return "";
}