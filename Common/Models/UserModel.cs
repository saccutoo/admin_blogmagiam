using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UserModel : BasicModel
    {
        public long id
        {
            get; set;
        }
        public string user_name
        {
            get; set;
        }
        public string pass_word
        {
            get; set;
        }
        public int block
        {
            get; set;
        }

        public string status_name
        {
            get; set;
        }
        public string token
        {
            get; set;
        }
    }
}
