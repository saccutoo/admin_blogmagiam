using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial interface IClickMerchantService
    {
        ResponseObject<List<ClickMerchantModel>> GetFilter(string model);
        ResponseObject<ClickMerchantModel> GetByIdAsync(int id);
        ResponseObject<ClickMerchantModel> AddChange(object model);
       
    }
}