using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaGiam.ViewModel
{
    public class MenuViewModel
    {
        public List<MenuModel> Datas { get; set; } = new List<MenuModel>();
        public string Path { get; set; }
        public string ApplicationPath { get; set; }
    }

}
