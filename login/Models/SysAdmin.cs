using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace login.Models
{
    [Serializable]
    public class SysAdmin
    {
        public int LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string AdminName { get; set; }
    }
}