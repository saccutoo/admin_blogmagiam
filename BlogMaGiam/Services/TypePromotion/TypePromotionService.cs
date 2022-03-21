using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class TypePromotionService : ITypePromotionService
    {
        private CommonService<TypePromotionModel> _commonService;
        private string urlGetAll= "api/typepromotion/get_all";
        public TypePromotionService()
        {
            _commonService = new CommonService<TypePromotionModel>();
        }

        public ResponseObject<List<TypePromotionModel>> GetAll ()
        {
            return _commonService.GetListApi(urlGetAll);
        }

    }
}