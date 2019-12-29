using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    [SugarTable("COMPANY")]
    public class COMPANY
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string LINK_MAN { get; set; }
        public string SALE_PRODUCT { get; set; }
        public string TEL { get; set; }
        public string ADDRESS { get; set; }
    }
}
