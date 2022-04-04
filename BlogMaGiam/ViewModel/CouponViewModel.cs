using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaGiam.ViewModel
{
    public class CouponViewModel
    {
        public List<CouponModel> Datas { get; set; } = new List<CouponModel>();
        public TableViewModel Table { get; set; } = new TableViewModel();
        public List<StatusModel> Status { get; set; } = new List<StatusModel>();
        public List<MerchantListModel> Merchants { get; set; } = new List<MerchantListModel>();
    }

    public class ChangeCouponViewModel
    {
        public CouponModel Data { get; set; } = new CouponModel();
        public List<MerchantListModel> Merchants { get; set; } = new List<MerchantListModel>();
    }
}
