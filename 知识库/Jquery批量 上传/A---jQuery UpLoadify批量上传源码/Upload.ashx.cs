using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace Web
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {
        //51aspx下载
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["FileData"];
            string uploadpath = context.Server.MapPath(context.Request["folder"] + "\\");

            if (file != null)
            {
                if (!Directory.Exists(uploadpath))
                {
                    Directory.CreateDirectory(uploadpath);
                }
                file.SaveAs(uploadpath + file.FileName);
                context.Response.Write("1|222"); //标志位1标识上传成功，后面的可以返回前台的参数，比如上传后的路径等，中间使用|隔开
            }
            else
            {
                context.Response.Write("0|");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}