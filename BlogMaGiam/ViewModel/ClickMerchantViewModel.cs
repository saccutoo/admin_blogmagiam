using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.ViewModel
{
    public class ClickMerchantViewModel
    {
        public List<ClickMerchantModel> Datas { get; set; } = new List<ClickMerchantModel>();
        public TableViewModel Table { get; set; } = new TableViewModel();
        public List<SeleteModel> TypeCalendars { get; set; } = Helper.ListSeletedTypeCalendar();
        public string Type { get; set; }
    }
}