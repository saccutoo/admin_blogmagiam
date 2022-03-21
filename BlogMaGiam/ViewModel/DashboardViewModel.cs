using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.ViewModel
{
    public class DashboardViewModel
    {
        public List<DashboardModel> Datas { get; set; } = new List<DashboardModel>();
        public int TotalDay { get; set; } = 0;
        public int TotalWeek { get; set; } = 0;
        public int TotalMonth { get; set; } = 0;
        public int TotalYear { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        public List<SeleteModel> TypeCalendars { get; set; } = Helper.ListSeletedTypeCalendar();
    }
}