using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.AuthModel
{
    public class AuthDataRespon
    {
        public int id { get; set; }
     //   public byte[] avatar { get; set; }
        public TokenModel Token { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string nickName { get; set; }
        public int role { get; set; }
    }
}
