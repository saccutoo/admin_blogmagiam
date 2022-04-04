using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class MerchantListModel : BasicModel
    {
        public string Id { get; set; }
        public string merchant_id { get; set; }
        public string display_name { get; set; }
        public string login_name { get; set; }
        public string logo { get; set; }
        public string logo_coupon { get; set; }
        public long total_offer { get; set; }
        public long is_hide { get; set; }
        public string description1 { get; set; }
        public string description2 { get; set; }
        public string description3 { get; set; }
        public string status_name { get; set; }

    }
    public class MerchantListCouponQuery : BasicQueryModel
    {
    }
}
