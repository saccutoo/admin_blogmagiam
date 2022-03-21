using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class ClickMerchantService : IClickMerchantService
    {
        private CommonService<ClickMerchantModel> _commonService;
        private string urlGetTopClickMerchantByFilter= "api/clickmerchant/get_filter";
        private string urlGetClickMerchantById = "api/clickmerchant/get_ClickMerchant_by_id";
        private string urlBase = "api/clickmerchant";
        public ClickMerchantService()
        {
            _commonService = new CommonService<ClickMerchantModel>();
        }

        public ResponseObject<List<ClickMerchantModel>> GetFilter (string model)
        {
            return _commonService.GetListApi(urlGetTopClickMerchantByFilter + "?data=" + model);
        }

        public ResponseObject<ClickMerchantModel> GetByIdAsync(int id)
        {
            return _commonService.GetApi(urlGetClickMerchantById + "?id=" + id.ToString());
        }
        public ResponseObject<ClickMerchantModel> AddChange(object model)
        {
            return _commonService.PostApi(urlBase, model);
        }
      
    }
}