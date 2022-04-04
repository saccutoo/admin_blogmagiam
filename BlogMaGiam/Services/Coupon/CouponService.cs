using Common.Helpers;
using Common.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class CouponService : ICouponService
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private CommonService<CouponModel> _commonService;
        private CommonService<List<Response>> _commonListService;
        private string urlGetByFilter= "api/coupon_list/filter";
        private string urlGetById = "api/coupon_list/get_by_id";
        private string urlUpdateStatus = "api/coupon_list/update-status";
        private string urlUpdateOrder = "api/coupon_list/update-order";
        private string urlBase = "api/coupon_list";
        public CouponService()
        {
            _commonService = new CommonService<CouponModel>();
            _commonListService = new CommonService<List<Response>>();
        }

        public ResponseObject<List<CouponModel>> GetByFilter(string model)
        {
            return _commonService.GetListApi(urlGetByFilter + "?data=" + model);
        }

        public ResponseObject<CouponModel> GetById(int id)
        {
            return _commonService.GetApi(urlGetById + "?id=" + id.ToString());
        }

        public ResponseObject<CouponModel> AddChange(object model)
        {
            return _commonService.PostApi(urlBase, model);
        }

        public ResponseObject<CouponModel> UpdateChange(object model)
        {
            return _commonService.PutApi(urlBase, model);
        }

        public ResponseObject<CouponModel> UpdateStatus(object model)
        {
            return _commonService.PutApi(urlUpdateStatus, model);
        }

        public ResponseObject<List<Response>> UpdateOrder(object model)
        {
            return _commonListService.PutApi(urlUpdateOrder, model);
        }
    }
}