﻿using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace AntiForgeryStrategiesCore
{
    public class TimeTokenAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
    {
        public string GetAdditionalData(HttpContext context)
        {
            return DateTime.Now.AddSeconds(10).ToString();
        }

        public bool ValidateAdditionalData(HttpContext context, string additionalData)
        {
            var expirationDateTime = DateTime.Parse(additionalData);
            return DateTime.Now < expirationDateTime;
        }
    }
}