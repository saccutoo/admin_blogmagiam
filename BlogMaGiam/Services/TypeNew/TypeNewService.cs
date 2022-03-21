using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class TypeNewService : ITypeNewService
    {
        private CommonService<TypeNewModel> _commonService;
        private string urlGetAll= "api/typenews/get_all";
        public TypeNewService()
        {
            _commonService = new CommonService<TypeNewModel>();
        }

        public ResponseObject<List<TypeNewModel>> GetAll ()
        {
            return _commonService.GetListApi(urlGetAll);
        }

    }
}