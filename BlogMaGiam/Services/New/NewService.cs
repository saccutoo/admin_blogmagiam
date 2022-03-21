using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class NewService : INewService
    {
        private CommonService<NewModel> _commonService;
        private string urlGetTopNewByFilter= "api/news/get_top_by_filter";
        private string urlGetNewById = "api/news/get_new_by_id";
        private string urlUpdateStatus = "api/news/update-status";
        private string urlBase = "api/news";
        public NewService()
        {
            _commonService = new CommonService<NewModel>();
        }

        public ResponseObject<List<NewModel>> GetTopNewByFilter (string model)
        {
            return _commonService.GetListApi(urlGetTopNewByFilter + "?data=" + model);
        }

        public ResponseObject<NewModel> GetNewByIdAsync(int id)
        {
            return _commonService.GetApi(urlGetNewById + "?id=" + id.ToString());
        }
        public ResponseObject<NewModel> AddChange(object model)
        {
            return _commonService.PostApi(urlBase, model);
        }

        public ResponseObject<NewModel> UpdateChange(object model)
        {
            return _commonService.PutApi(urlBase, model);
        }

        public ResponseObject<NewModel> DeleteChange(object model)
        {
            return _commonService.PostApi(urlBase, model);
        }

        public ResponseObject<NewModel> UpdateStatus(object model)
        {
            return _commonService.PutApi(urlUpdateStatus, model);
        }
    }
}