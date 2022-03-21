using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaGiam.ViewModel
{
    public class NewViewModel
    {
        public List<NewModel> Datas { get; set; } = new List<NewModel>();
        public TableViewModel Table { get; set; } = new TableViewModel();
        public List<StatusModel> Status { get; set; } = new List<StatusModel>();
    }

    public class ChangeNewViewModel
    {
        public NewModel Data { get; set; } = new NewModel();
        public List<TypeNewModel> TypeNews { get; set; } =new List<TypeNewModel>();
        public List<TypePromotionModel> TypePromotions { get; set; } = new List<TypePromotionModel>();
    }
}
