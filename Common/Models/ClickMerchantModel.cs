using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ClickMerchantModel : BasicModel
    {
        public long id
        {
            get; set;
        }
        public string ip
        {
            get; set;
        }
        public string merchant_name
        {
            get; set;
        }
        public string aff_link
        {
            get; set;
        }
    }

    public class ClickMerchantQuery : BasicQueryModel
    {
        public string Type { get; set; }
    }
}
