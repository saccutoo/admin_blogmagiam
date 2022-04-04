using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial interface ICouponService
    {
        ResponseObject<List<CouponModel>> GetByFilter(string model);
        ResponseObject<CouponModel> GetById(int id);
        ResponseObject<CouponModel> AddChange(object model);
        ResponseObject<CouponModel> UpdateChange(object model);
        ResponseObject<CouponModel> UpdateStatus(object model);
        ResponseObject<List<Response>> UpdateOrder(object model);
    }
}