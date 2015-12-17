using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firma.Framework;

namespace ManuelaKajkara
{
    public static class Extensions
    {
        public static void ValidateBusinessObject(this ModelStateDictionary ModelState, BusinessBase businessObject)
        {
            businessObject.Validate();
            foreach (var pair in businessObject.GetValidationErrors())
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    ModelState.AddModelError(pair.Key, pair.Value);
                }
            }
        }
    }
}