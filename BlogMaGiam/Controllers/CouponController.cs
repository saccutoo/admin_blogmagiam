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
using Common;
using System.Configuration;
using System.Globalization;
using NLog;

namespace BlogMaGiam.Controllers
{
    public class CouponController : BaseController
    {
        private ICouponService _couponService;
        private IStatusService _statusService;
        private IMerchantService _merchantService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public CouponController(ICouponService couponService,  IStatusService statusService, IMerchantService merchantService)
        {
            _couponService = couponService;
            _statusService = statusService;
            _merchantService = merchantService;
        }
        public ActionResult Index()
        {
            CouponQuery query = new CouponQuery();
            query.type = Constant.COUPON_BLOGMAGIAM;
            var vm = GetDatas(query);
            var status = _statusService.GetAll();
            if (status != null && status.Data != null && status.Data.Count > 0)
            {
                vm.Status = status.Data;
            }

            var merchant = _merchantService.GetMerchantActive();
            if (merchant != null && merchant.Data != null && merchant.Data.Count > 0)
            {
                vm.Merchants = merchant.Data;
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult ViewList(CouponQuery query)
        {
            CouponViewModel vm = new CouponViewModel();           
            vm = GetDatas(query);
            return View("_ListView", vm);
        }

        [HttpGet]
        public CouponViewModel GetDatas(CouponQuery query)
        {
            CouponViewModel vm = new CouponViewModel();
            vm.Table.PageIndex = query.pageIndex;
            vm.Table.PageSize = query.pageSize;
            var response = _couponService.GetByFilter(JsonConvert.SerializeObject(query));
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
            ChangeCouponViewModel vm = new ChangeCouponViewModel();
            vm.Data.start_date = DateTime.ParseExact(DateTime.Now.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"] + " 00:00:00"), ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"], CultureInfo.InvariantCulture);
            vm.Data.end_date = DateTime.ParseExact(DateTime.Now.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"] + " 23:59:50"), ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"], CultureInfo.InvariantCulture);
            var merchant = _merchantService.GetMerchantActive();
            if (merchant != null && merchant.Data != null && merchant.Data.Count > 0)
            {
                vm.Merchants = merchant.Data;
            }
            return View("_Change", vm);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Change(CouponModel model)
        {
            List<ValidateModel> validates = new List<ValidateModel>();
            if (string.IsNullOrEmpty(model.aff_link))
            {
                validates.Add(new ValidateModel() { Key = "aff_link-message-danger", Value = "Do not leave blank" });
            }
            if (string.IsNullOrEmpty(model.image))
            {
                validates.Add(new ValidateModel() { Key = "image-message-danger", Value = "Do not leave blank" });
            }
            if (string.IsNullOrEmpty(model.name))
            {
                validates.Add(new ValidateModel() { Key = "name-message-danger", Value = "Do not leave blank" });
            }
            if (string.IsNullOrEmpty(model.merchant))
            {
                validates.Add(new ValidateModel() { Key = "merchant-message-danger", Value = "You have not selected" });
            }
            if (string.IsNullOrEmpty(model.coupon_code))
            {
                validates.Add(new ValidateModel() { Key = "coupon_code-message-danger", Value = "Do not leave blank" });
            }
            if (string.IsNullOrEmpty(model.content))
            {
                validates.Add(new ValidateModel() { Key = "content-message-danger", Value = "Do not leave blank" });
            }
            if (model.remain==null)
            {
                validates.Add(new ValidateModel() { Key = "remain-message-danger", Value = "Do not leave blank" });
            }
            //if (model.start_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"])=="01/01/0001")
            //{
            //    validates.Add(new ValidateModel() { Key = "start_date-message-danger", Value = "Do not leave blank" });
            //}
            //if (model.end_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"]) == "01/01/0001")
            //{
            //    validates.Add(new ValidateModel() { Key = "end_date-message-danger", Value = "Do not leave blank" });
            //}

            if (string.IsNullOrEmpty(model.start_date_string))
            {
                validates.Add(new ValidateModel() { Key = "start_date_string-message-danger", Value = "Do not leave blank" });
            }
            if (string.IsNullOrEmpty(model.end_date_string))
            {
                validates.Add(new ValidateModel() { Key = "end_date_string-message-danger", Value = "Do not leave blank" });
            }

            if (!string.IsNullOrEmpty(model.start_date_string))
            {
                try
                {
                    model.start_date = DateTime.ParseExact(model.start_date_string, ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"], CultureInfo.InvariantCulture);

                }
                catch (Exception)
                {
                    validates.Add(new ValidateModel() { Key = "start_date_string-message-danger", Value = "Wrong date format" });
                }
            }
            if (!string.IsNullOrEmpty(model.end_date_string))
            {
                try
                {
                    model.end_date = DateTime.ParseExact(model.end_date_string, ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"], CultureInfo.InvariantCulture);

                }
                catch (Exception)
                {
                    validates.Add(new ValidateModel() { Key = "end_date_string-message-danger", Value = "Wrong date format" });
                }
            }
            if (
                model.start_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"])!="01/01/0001" &&
                model.end_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATE_CONVERT"]) != "01/01/0001" &&
                model.start_date > model.end_date
               )
            {
                validates.Add(new ValidateModel() { Key = "end_date-message-danger", Value = "End date must be greater than start date" });
            }


            if (validates.Count>0)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    validate=true,
                    validates
                }));
            }
            var response = new ResponseObject<CouponModel>();
            model.type = Constant.COUPON_BLOGMAGIAM;
            //model.start_date_string = model.start_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"]);
            //model.end_date_string = model.end_date.ToString(ConfigurationManager.AppSettings["FORMAT_DATETIME_CONVERT"]);
            if (model.id=="0" || string.IsNullOrEmpty(model.id))
            {
                response = _couponService.AddChange(model);
            }
            else
            {
                response = _couponService.UpdateChange(model);
            }
            
            return Content(JsonConvert.SerializeObject(new
            {
                response
            }));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ChangeCouponViewModel vm = new ChangeCouponViewModel();
            vm.Data.id = id.ToString();
            var coupon = _couponService.GetById(id);
            if (coupon != null && coupon.Data != null)
            {
                vm.Data = coupon.Data;
            }
            var merchant = _merchantService.GetMerchantActive();
            if (merchant != null && merchant.Data != null && merchant.Data.Count > 0)
            {
                vm.Merchants = merchant.Data;
            }
            return View("_Change", vm);
        }

        [HttpPost]
        public ActionResult UpdateStatus(CouponDeleteModel model)
        {
            var response = _couponService.UpdateStatus(model);
            return Content(JsonConvert.SerializeObject(new
            {
                response
            }));
        }

        [HttpPost]
        public ActionResult Order(CouponQuery query)
        {
            CouponViewModel vm = new CouponViewModel();
            query.pageIndex = 1;
            query.pageSize = int.MaxValue;
            vm = GetDatas(query);
            return View("_Sort", vm);
        }

        [HttpPost]
        public ActionResult UpdateOrder(List<CouponModel> datas)
        {
            var response = _couponService.UpdateOrder(datas);
            return Content(JsonConvert.SerializeObject(new
            {
                response
            }));
        }

        [HttpGet]
        public ActionResult Clone(int id)
        {
            ChangeCouponViewModel vm = new ChangeCouponViewModel();
            vm.Data.id = id.ToString();
            var coupon = _couponService.GetById(id);
            if (coupon != null && coupon.Data != null)
            {
                vm.Data = coupon.Data;
            }
            var merchant = _merchantService.GetMerchantActive();
            if (merchant != null && merchant.Data != null && merchant.Data.Count > 0)
            {
                vm.Merchants = merchant.Data;
            }
            vm.Data.id = string.Empty;
            return View("_Change", vm);
        }
    }
}