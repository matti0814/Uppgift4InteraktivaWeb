using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uppgift4Interaktiva.Models
{
    public class ValidateUser
    {

        public static bool IsUserValid()
        {
            HttpContext content = HttpContext.Current;
            if (content.Session["userId"] != null)
            {
                return true;
            }
            else
                return false;
        }

    }
}