using BlogMaGiam.Services;
using BlogMaGiam.ViewModel;
using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BlogMaGiam.Controllers
{
    public class ClickMerchantController : BaseController
    {
        private IClickMerchantService _ClickMerchantService;
        public ClickMerchantController(IClickMerchantService ClickMerchantService)
        {
            _ClickMerchantService = ClickMerchantService;
        }
        public ActionResult Index(string type="ALL")
        {
            ClickMerchantQuery query = new ClickMerchantQuery();
            query.Type = type;
            var vm = GetDatas(query);

            return View(vm);
        }

        [HttpPost]
        public ActionResult ViewList(ClickMerchantQuery query)
        {
            ClickMerchantViewModel vm = new ClickMerchantViewModel();           
            vm = GetDatas(query);
            return View("_ListView", vm);
        }

        [HttpGet]
        public ClickMerchantViewModel GetDatas(ClickMerchantQuery query)
        {
            ClickMerchantViewModel vm = new ClickMerchantViewModel();
            vm.Table.PageIndex = query.pageIndex;
            vm.Table.PageSize = query.pageSize;
            vm.Type = query.Type;
            var response = _ClickMerchantService.GetFilter(JsonConvert.SerializeObject(query));
            if (response!=null && response.Data!=null && response.Data!=null)
            {
                vm.Datas = response.Data;
                if (response.OutData!=null && response.OutData.Count>0)
                {
                    if (response.OutData["P_TOTAL"]!=null)
                    {
                        vm.Table.Total = Convert.ToInt32(response.OutData["P_TOTAL"].ToString());
                    }
                    
                }
            }
            return vm;
        }
      
    }
}