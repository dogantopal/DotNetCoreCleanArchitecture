using Application.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace WebUI.Extensions
{
    public static class CookieAuthenticationExtensions
    {
        public static void AddCookieAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(x =>
            {
                x.Cookie.HttpOnly = true;
                x.LoginPath = "/Auth/Login";
                x.LogoutPath = "/Auth/Logout";
                x.SlidingExpiration = true;
                x.AccessDeniedPath = "/Auth/AccessDenied";
                x.ExpireTimeSpan = TimeSpan.FromHours(2);
            });
        }

        public static IIdentity SignIn(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Surname, user.Surname));

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
