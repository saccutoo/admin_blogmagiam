using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class TypePromotionModel :  BasicModel
    {
        public long id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string status_name
        {
            get; set;
        }
    }

}
