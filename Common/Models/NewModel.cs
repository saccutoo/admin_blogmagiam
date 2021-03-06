using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class NewModel :  BasicModel
    {
        public long id
        {
            get; set;
        }
        public string code
        {
            get; set;
        }
        public string title
        {
            get; set;
        }
        public string content
        {
            get; set;
        }
        public string image
        {
            get; set;
        }
        public long type
        {
            get; set;
        }

        public string link
        {
            get; set;
        }
        public long type_merchant
        {
            get; set;
        }
        public string type_merchant_name
        {
            get; set;
        }
        public string status_name
        {
            get; set;
        }
        public string type_name
        {
            get; set;
        }
    }

    public class NewsQuery : BasicQueryModel
    {

    }
}
