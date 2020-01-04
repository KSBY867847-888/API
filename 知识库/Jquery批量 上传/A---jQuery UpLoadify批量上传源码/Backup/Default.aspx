<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>批量上传</title>
     <link rel="Stylesheet" href="Scripts/uploadify.css" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/swfobject.js"></script>
    <script type="text/javascript" src="Scripts/jquery.uploadify.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#custom_file_upload').uploadify({
                'uploader': '/Scripts/uploadify.swf',
                'script': '/Upload.ashx',
                'cancelImg': '/Scripts/uploadify-cancel.png',
                'folder': '/Upload',
                'multi': true,
                'auto': true,
                'fileExt': '*.jpg;*.gif;*.png',
                'fileDesc': 'Image Files (.JPG, .GIF, .PNG)',
                'queueID': 'custom-queue',
                'queueSizeLimit': 999,
                'simUploadLimit': 999,
                'buttonText': '选择文件',
                'removeCompleted': false,
                'onSelectOnce': function (event, data) {
                    $('#status-message').text(data.filesSelected + ' 个文件加入上传队列');
                },
                'onComplete': function (event, queueId, fileObj, response, data) {
                    //alert(response.split('|')[1]); //这里获取上传后的URL路径，用来在前台显示 
                },
                'onAllComplete': function (event, data) {
                    $('#status-message').text(data.filesUploaded + ' 个文件已上传');
                }
            });
        });
    </script>
    <style type="text/css">
    body{font-size:14px; font-family:微软雅黑;}
    #custom-demo .uploadifyQueueItem {
      background-color: #FFFFFF;
      border: none;
      border-bottom: 1px solid #E5E5E5;
      font: 11px Verdana, Geneva, sans-serif;
      height: 20px;
      margin-top: 0;
      padding: 10px;
      width: 350px;
    }
    #custom-demo #custom-queue {
      border: 1px solid #E5E5E5;
      margin-bottom: 10px;
      width: 370px;
    }
    </style>
</head>
<body>
    <div id="custom-demo" class="demo">
        <div class="demo-box">
            <div id="status-message">请选择要上传的文件:</div>
            <div id="custom-queue"></div>
            <input id="custom_file_upload" type="file" name="Filedata" />
        </div>
    </div>
</body>
</html>
