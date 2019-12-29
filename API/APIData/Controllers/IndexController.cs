using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIData.Controllers
{
    public class IndexController : ApiController
    {
        [HttpGet]
        [Route("API/Index/GetCompanyByID")]
        public IHttpActionResult GetCompanyByID(string id)
        {
            var db = DB.GetInstance();
            var comp = db.Queryable<COMPANY>().Where(n => n.ID == id).First();
            return Json(comp);
        }
    }
}
