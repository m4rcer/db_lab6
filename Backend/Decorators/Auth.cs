using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http.Controllers;
using Backend.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Decorators
{
    public class Auth : Attribute, IAuthorizationFilter
    {
        private List<string> _roles;

        public Auth(params string[] roles)
        {
            _roles = roles.ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var email = context.HttpContext.Request.Headers["email"].ToString();
            var password = context.HttpContext.Request.Headers["password"].ToString();

               var user = EmployeeService.GetByEmail(email);

            if (user.EMPLOYEE_SPECIALIZATION_NAME == "Администратор")
                return;

            if (user.EMPLOYEE_PASSWORD == password && _roles.Contains(user.EMPLOYEE_SPECIALIZATION_NAME))
                return;

            context.Result = new UnauthorizedResult();
        }
    }
}
