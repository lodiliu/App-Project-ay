



//关闭提示框
function closeTip() {
    document.getElementById("hbg").style.display = "none";
    document.getElementById("alertM").style.display = "none";
}

//点赞操作
function dolike(userid, cid, obj) {
    if (userid.length < 28) {
        document.getElementById("hbg").style.display = "inline";
        document.getElementById("alertM").style.display = "inline";
        return;
    }
    else {
        $.ajax({
            type: "get",
            data: "{'userid':'" + userid + "','commentid':'" + cid + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "API/GetFindPlay/GetFindPlayByLike?userid=" + userid + "&commentid=" + cid,
            success: function (data) {
                if (data.Code == 200) {
                    if (obj.className == "item-after active") {
                        var int_n = parseInt(obj.innerHTML);
                        obj.innerHTML = int_n + 1;
                    }
                    else {
                        var int_n = parseInt(obj.innerHTML);
                        obj.innerHTML = int_n - 1;
                    }
                }
                else {
                    alert(data.Msg);
                }
            },
            error: function (data) {
                alert("请检查网络");
            }
        });
    }
}