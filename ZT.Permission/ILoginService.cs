using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Enums;

namespace ZT.Permission
{
    public interface ILoginService
    {
        AccountStatusEnum Login(string userName, string passWord);

        string Md5(string str, int code);
    }
}
