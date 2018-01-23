function showProcessTip(obj, txt) {
    $(obj).show();
    $(obj).html(txt);
    $(obj).delay(3000).fadeOut(0);
}
function preLoad() {
	if (!this.support.loading) {
	    alert("您需要Flash Player 9.028或更高版本才可以用Flash上传.");
		return false;
	}
}
function loadFailed() {
	alert("加载Flash上传工具失败.");
}
//上传错误
function fileQueueError(file, errorCode, message) {
    try {
        switch (errorCode) {
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                alert("上传的文件大小为0字节");
                break;
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                alert("上传的文件超过最大限制");
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                alert("文件类型不正确");
                break;
            case SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED:
                alert("选择的文件数量超过限制，还能选择文件个数为" + message);
                break;
            default:
                alert(message);
                break;
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//上传处理
function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 0) {
            this.startUpload();
        }
    } catch (ex) {
        this.debug(ex);
    }
}
//上传处理
function uploadComplete(file) {
    try {
        if (this.getStats().files_queued > 0) {
            this.startUpload();
        } else {

        }
    } catch (ex) {
        this.debug(ex);
    }
}
//上传错误事件
function uploadError(file, errorCode, message) {
    var progress;
    try {
        switch (errorCode) {
            case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                try {
                    alert("FILE_CANCELLED");
                }
                catch (ex1) {
                    this.debug(ex1);
                }
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                try {
                    alert("UPLOAD_STOPPED");
                }
                catch (ex2) {
                    this.debug(ex2);
                }
            case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                alert("LIMIT_EXCEEDED");
                break;
            default:
                alert(message);
                break;
        }

    } catch (ex3) {
        this.debug(ex3);
    }
}
//上传进度事件
function uploadProgress(file, bytesLoaded) {
}
//上传成功处理事件
function uploadSuccess(file, serverData) {
    try {
        var r = eval("(" + serverData + ")");
        if (r.IsSuccess) {
            $("#showPic").html('<input class="hidden" name="hidPic" value="' + r.Data.url + '" type="checkbox" checked="checked" /><img src="' + r.Data.url + '" /><a href="' + r.Data.url + '" target=\"_blank\" title=\"点击查看原图\">查看</a><a class="ml12" href="javascript:;" onclick="del(this)" guid="' + r.Data.guid + '">删除</a>');
        }
    } catch (ex) {
        this.debug(ex);
    }
}
