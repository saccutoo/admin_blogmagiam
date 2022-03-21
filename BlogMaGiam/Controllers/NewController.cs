using BlogMaGiam.Services;
using BlogMaGiam.ViewModel;
using Common.Helpers;
using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMaGiam.Controllers
{
    public class NewController : BaseController
    {
        private INewService _newService;
        private ITypeNewService _typeNewService;
        private ITypePromotionService _typePromotionService;
        private IStatusService _statusService;
        public NewController(INewService newService, ITypeNewService typeNewService, ITypePromotionService typePromotionService, IStatusService statusService)
        {
            _newService = newService;
            _typeNewService = typeNewService;
            _typePromotionService = typePromotionService;
            _statusService = statusService;
        }
        public ActionResult Index()
        {
            NewsQuery query = new NewsQuery();
            var vm = GetDatas(query);
            var status = _statusService.GetAll();
            if (status != null && status.Data != null && status.Data.Count > 0)
            {
                vm.Status = status.Data;
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult ViewList(NewsQuery query)
        {
            NewViewModel vm = new NewViewModel();           
            vm = GetDatas(query);
            return View("_ListView", vm);
        }

        [HttpGet]
        public NewViewModel GetDatas(NewsQuery query)
        {
            NewViewModel vm = new NewViewModel();
            vm.Table.PageIndex = query.pageIndex;
            vm.Table.PageSize = query.pageSize;
            var response = _newService.GetTopNewByFilter(JsonConvert.SerializeObject(query));
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

        [HttpGet]
        public ActionResult Add()
        {
            ChangeNewViewModel vm = new ChangeNewViewModel();
            var typeNew = _typeNewService.GetAll();
            if (typeNew != null && typeNew.Data != null && typeNew.Data.Count > 0)
            {
                vm.TypeNews = typeNew.Data;
            }

            var typePromotionService = _typePromotionService.GetAll();
            if (typePromotionService != null && typePromotionService.Data != null && typePromotionService.Data.Count > 0)
            {
                vm.TypePromotions= typePromotionService.Data;
            }
            return View("_Change", vm);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Change(NewModel model)
        {
            var response = new ResponseObject<NewModel>();
            if (model.id==0)
            {
                response = _newService.AddChange(model);
            }
            else
            {
                response = _newService.UpdateChange(model);
            }
            
            return Content(JsonConvert.SerializeObject(new
            {
                response
            }));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ChangeNewViewModel vm = new ChangeNewViewModel();
            vm.Data.id = id;
            var _new = _newService.GetNewByIdAsync(id);
            if (_new != null && _new.Data != null)
            {
                vm.Data = _new.Data;
            }
            var typeNew = _typeNewService.GetAll();
            if (typeNew != null && typeNew.Data != null && typeNew.Data.Count > 0)
            {
                vm.TypeNews = typeNew.Data;
            }
            var typePromotionService = _typePromotionService.GetAll();
            if (typePromotionService != null && typePromotionService.Data != null && typePromotionService.Data.Count > 0)
            {
                vm.TypePromotions = typePromotionService.Data;
            }
            return View("_Change", vm);
        }

        [HttpPost]
        public ActionResult UpdateStatus(NewModel model)
        {
            var response = _newService.UpdateStatus(model);
            return Content(JsonConvert.SerializeObject(new
            {
                response
            }));
        }
    }
}