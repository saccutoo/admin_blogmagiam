using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class StatusService : IStatusService
    {
        private CommonService<StatusModel> _commonService;
        private string urlGetAll= "api/status/get_all";
        public StatusService()
        {
            _commonService = new CommonService<StatusModel>();
        }

        public ResponseObject<List<StatusModel>> GetAll ()
        {
            return _commonService.GetListApi(urlGetAll);
        }

    }
}