using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBDMO3.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { set; get; }
        public string Username { set; get; }
    }
}