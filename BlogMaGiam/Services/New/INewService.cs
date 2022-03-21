using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial interface INewService
    {
        ResponseObject<List<NewModel>> GetTopNewByFilter(string model);
        ResponseObject<NewModel> GetNewByIdAsync(int id);
        ResponseObject<NewModel> AddChange(object model);
        ResponseObject<NewModel> UpdateChange(object model);
        ResponseObject<NewModel> DeleteChange(object model);
        ResponseObject<NewModel> UpdateStatus(object model);
    }
}