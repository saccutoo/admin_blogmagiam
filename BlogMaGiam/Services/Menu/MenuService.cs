using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class MenuService : IMenuService
    {
        private CommonService<MenuModel> _commonService;
        private string urlGetAll= "api/menu/get_all";
        private string urlGetMenuById = "api/by_id";
        private string urlBase = "api/menu";
        public MenuService()
        {
            _commonService = new CommonService<MenuModel>();
        }

        public ResponseObject<List<MenuModel>> GetAllMenu (string type)
        {
            return _commonService.GetListApi(urlGetAll + "?type=" + type);
        }

        public ResponseObject<MenuModel> GetMenuByIdAsync(int id)
        {
            return _commonService.GetApi(urlGetMenuById + "?id=" + id.ToString());
        }
        
    }
}