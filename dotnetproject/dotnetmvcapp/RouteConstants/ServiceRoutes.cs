using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetmvcapp.RouteConstants
{
    public static class AccountServiceRoutes
    {
        public static string Login = @"/api/Account/Login";
        public static string Register = @"/api/Account/Register";
    }

    public static class OrderServiceRoutes
    {
        public static string GetAllOrders = @"/api/Order/GetAllOrders";
    }
}