using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using ZT.Permission.Models;
using ZT.Permission.Enums;

namespace ZT.Permission.Service
{
    public class LoginService : ILoginService
    {
        public AccountStatusEnum Login(string userName, string passWord) 
        {
            return AccountStatusEnum.Active;
        }

        public string Md5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            if (code == 32) //32位加密 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
            return "00000000000000000000000000000000";
        } 
    }
}
