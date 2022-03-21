using BlogMaGiam.Services;
using BlogMaGiam.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace BlogMaGiam.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService _menuService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
       
        [HttpGet]
        public ActionResult Menu()
        {
            MenuViewModel vm = new MenuViewModel();
            try
            {
                vm.Path = HttpContext.Request.Url.ToString();
                vm.ApplicationPath = HttpContext.Request.AppRelativeCurrentExecutionFilePath.ToString();
                var responseMenus = _menuService.GetAllMenu(Constant.ACTIVE);
                if (responseMenus != null && responseMenus.Data != null && responseMenus.Data.Count > 0)
                {
                    vm.Datas = responseMenus.Data;
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
            return View(vm);
        }     
    }
}