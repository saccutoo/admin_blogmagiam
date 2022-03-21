using BlogMaGiam.Services;
using BlogMaGiam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMaGiam.Controllers
{
    public class HomeController : BaseController
    {
        private IDashboardService _dashboardService;
        public HomeController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public ActionResult Index(string type="DAY")
        {
            DashboardViewModel vm = new DashboardViewModel();
            vm.Type = type;
            vm = GetDatas(vm);
            return View(vm);
        }

        [HttpGet]
        public ActionResult ViewList(string type)
        {
            DashboardViewModel vm = new DashboardViewModel();
            vm.Type = type;
            vm = GetDatas(vm);
            return View("_ListView", vm);
        }


        [HttpGet]
        public DashboardViewModel GetDatas(DashboardViewModel vm)
        {
            var response = _dashboardService.GetCountClickMerchant(vm.Type);
            if (response != null && response.Data != null && response.Data != null)
            {
                vm.Datas = response.Data;
            }
            if (response != null && response.OutData != null && response.OutData.Count > 0)
            {
                if (response.OutData["P_OUT_TOTAL"] != null)
                {
                    vm.Total = Convert.ToInt32(response.OutData["P_OUT_TOTAL"].ToString());
                }
                if (response.OutData["P_OUT_TOTAL_DAY"] != null)
                {
                    vm.TotalDay = Convert.ToInt32(response.OutData["P_OUT_TOTAL_DAY"].ToString());
                }
                if (response.OutData["P_OUT_TOTAL_WEEK"] != null)
                {
                    vm.TotalWeek = Convert.ToInt32(response.OutData["P_OUT_TOTAL_WEEK"].ToString());
                }
                if (response.OutData["P_OUT_TOTAL_MONTH"] != null)
                {
                    vm.TotalMonth = Convert.ToInt32(response.OutData["P_OUT_TOTAL_MONTH"].ToString());
                }
                if (response.OutData["P_OUT_TOTAL_YEAR"] != null)
                {
                    vm.TotalYear = Convert.ToInt32(response.OutData["P_OUT_TOTAL_YEAR"].ToString());
                }
            }
            return vm;
        }
    }
}