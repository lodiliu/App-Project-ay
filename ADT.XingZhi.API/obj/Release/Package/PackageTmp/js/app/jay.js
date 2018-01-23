/*
global
	require, jQBrowser, $,window,document,setTimeout
*/
document.onreadystatechange = function () {
    if (document.readyState == "interactive") {
        var DomParent = document.getElementsByClassName('comment-list');
        if (DomParent.length) {
            DomParent[0].addEventListener("click", function (e) {
                if ($("#hid_userid").val() != "" && window.navigator.onLine == true) {//用户登录过后才可以出现点击效果
                    if (e.target.classList.contains("item-after")) {
                        var _target = e.target;
                        _target.classList.toggle('active');
                    }
                }
                //e.stopPropagation();
            }, false);
        }

        var loaderbtn = document.getElementsByClassName("loadmore");
        var progressTimer = null;
        var setProgressTimer = function (_target) {
            var k = _target;
            return setTimeout(function () {
                k.classList.remove("onProgress");
                k.classList.add("progress-timeout");
            }, 10000);
        };
        var progressDone = function (_target) {
            _target.classList.remove('onProgress');
            _target.classList.remove('progress-timeout');
            if (progressTimer !== null) {
                clearTimeout(progressTimer);
            }
        };

        if (loaderbtn.length) {
            loaderbtn[0].addEventListener("click", function (e) {
                if (e.target.classList.contains("onProgress")) {
                    return;
                }
                if (e.target.classList.contains("trigger_button")) {
                    var _target = e.target;
                    _target.classList.remove('progress-timeout');
                    _target.classList.add('onProgress');
                    progressTimer = setProgressTimer(_target);

                    //加载数据下一页数据
                    LoadMore();

                    progressDone(_target);
                    /* 
						这里插入加载数据的方法
						数据加载完之后执行:
						progressDone(_target);
					*/
                }
                //e.stopPropagation();
            }, false);
        }

        //domready	
    }
};
