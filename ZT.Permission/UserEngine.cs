﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZT.Permission
{
    public class UserEngine:IDisposable
    {
        private static IDictionary<Type, object> container = new Dictionary<Type, object>();

        static UserEngine()
        {
            Register(typeof(IUserService), new Service.UserService());
            Register(typeof(IPermissionService), new Service.PermissionService());
            Register(typeof(ILoginService), new Service.LoginService());
        }

        static void Register(Type t, object o)
        {
            container.Add(new KeyValuePair<Type, object>(t, o));
        }

        public static T GetProvider<T>()
        {
            return (T)container[typeof(T)];
        }

        //
        public void Dispose()
        { 
            
        }
    }
}
