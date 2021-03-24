using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebUI.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public int UserId
        {
            get
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Convert.ToInt32(id);
            }
        }
    }
}
