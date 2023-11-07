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
        public static string Update = @"/api/Account/Update";
        public static string GetUserByEmail = @"/api/Account/GetUserDetailsByEmail/{email}";
        public static string GetUserById = @"/api/Account/GetUserDetailsById/{Id}";
        public static string GetAllUsers = @"/api/Account/GetAllUsers";
    }

    public static class OrderServiceRoutes
    {
        public static string GetAllOrders = @"/api/Order/GetAllOrders";
        public static string GetOrderById = @"/api/Order/GetOrderById/{id}";
        public static string UpdateOrder = @"/api/Order/UpdateOrder";
        public static string CreateOrder = @"/api/Order/CreateOrder";
        public static string DeleteOrder = @"/api/Order/DeleteOrder";
        public static string UpdateDelivery = @"/api/Order/UpdateDelivery";
    }
}