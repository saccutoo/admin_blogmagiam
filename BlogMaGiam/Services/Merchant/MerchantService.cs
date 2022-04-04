using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class MerchantService : IMerchantService
    {
        private CommonService<MerchantListModel> _commonService;
        private string urlGetAll= "api/merchant_list/get_all_merchant";
        public MerchantService()
        {
            _commonService = new CommonService<MerchantListModel>();
        }

        public ResponseObject<List<MerchantListModel>> GetMerchantActive()
        {
            return _commonService.GetListApi(urlGetAll);
        }

    }
}