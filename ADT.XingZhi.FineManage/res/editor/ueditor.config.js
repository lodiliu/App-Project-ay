
(function () {
    var URL = window.UEDITOR_HOME_URL || getUEBasePath();
    window.UEDITOR_CONFIG = {
        //为编辑器实例添加一个路径，这个不能被注释
        UEDITOR_HOME_URL : URL
        //文件目录
        , UEDITOR_UPLOAD_DIR: DIR
        //图片上传配置区
        , imageUrl: UEDITOR_UPLOAD_URL       //图片上传提交地址
        , imagePath: DIR                     //图片修正地址，引用了fixedImagePath,如有特殊需求，可自行配置
        //工具栏上的所有的功能按钮和下拉框，可以在new编辑器的实例时选择自己需要的从新定义
        , toolbars: [
            ['fullscreen', 'source', '|', 'undo', 'redo', '|',
                'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
                'rowspacingtop', 'rowspacingbottom', 'lineheight', '|',
                'customstyle', 'paragraph', 'fontfamily', 'fontsize', '|',
                'directionalityltr', 'directionalityrtl', 'indent', '|',
                'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|', 'touppercase', 'tolowercase', '|',
                'link', 'unlink', 'anchor', '|', 'imagenone', 'imageleft', 'imageright', 'imagecenter', '|',
                'insertimage', 'pagebreak', 'horizontal', '|',
                'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow', 'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown', 'splittocells', 'splittorows', 'splittocols', '|',
                'preview', 'searchreplace']
        ]
    };
    function getUEBasePath ( docUrl, confUrl ) {
        return getBasePath( docUrl || self.document.URL || self.location.href, confUrl || getConfigFilePath() );
    }
    function getConfigFilePath () {
        var configPath = document.getElementsByTagName('script');
        return configPath[ configPath.length -1 ].src;
    }
    function getBasePath ( docUrl, confUrl ) {
        var basePath = confUrl;
        if(/^(\/|\\\\)/.test(confUrl)){

            basePath = /^.+?\w(\/|\\\\)/.exec(docUrl)[0] + confUrl.replace(/^(\/|\\\\)/,'');

        }else if ( !/^[a-z]+:/i.test( confUrl ) ) {
            docUrl = docUrl.split( "#" )[0].split( "?" )[0].replace( /[^\\\/]+$/, '' );
            basePath = docUrl + "" + confUrl;
        }
        return optimizationPath( basePath );
    }
    function optimizationPath ( path ) {
        var protocol = /^[a-z]+:\/\//.exec( path )[ 0 ],
            tmp = null,
            res = [];
        path = path.replace( protocol, "" ).split( "?" )[0].split( "#" )[0];
        path = path.replace( /\\/g, '/').split( /\// );
        path[ path.length - 1 ] = "";
        while ( path.length ) {
            if ( ( tmp = path.shift() ) === ".." ) {
                res.pop();
            } else if ( tmp !== "." ) {
                res.push( tmp );
            }
        }
        return protocol + res.join( "/" );
    }
    window.UE = {
        getUEBasePath: getUEBasePath
    };
})();
