using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class DashboardService : IDashboardService
    {
        private CommonService<DashboardModel> _commonService;
        private string urlGetCountClickMerchant = "api/dashboard/get_count_click_merchant";
        private string urlBase = "api/dashboard";
        public DashboardService()
        {
            _commonService = new CommonService<DashboardModel>();
        }

        public ResponseObject<List<DashboardModel>> GetCountClickMerchant(string type)
        {
            return _commonService.GetListApi(urlGetCountClickMerchant + "?type=" + type);
        }

        
      
    }
}