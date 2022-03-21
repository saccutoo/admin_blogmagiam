using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class BasicModel
    {
        public DateTime? create_date
        {
            get; set;
        }
        public DateTime? update_date
        {
            get; set;
        }
        public string create_by
        {
            get; set;
        }
        public string update_by
        {
            get; set;
        }
        public int status
        {
            get; set;
        }
    }

    public class BasicQueryModel
    {
        public int status
        {
            get; set;
        } = 0;
        public string value
        {
            get; set;
        } = string.Empty;
        public int pageIndex
        {
            get; set;
        } = 1;
        public int pageSize
        {
            get; set;
        } = 20;
    }

    public class SeleteModel
    {
        public string Value
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
    }
}
