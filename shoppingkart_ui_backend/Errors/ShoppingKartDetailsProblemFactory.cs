﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace shoppingkart_ui_backend.Errors
{
    public class ShoppingKartDetailsProblemFactory:ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;
        public ShoppingKartDetailsProblemFactory(IOptions<ApiBehaviorOptions> options)
        {
            _options = options?.Value??throw new ArgumentNullException(nameof(options));
        }
        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext, 
            int? statusCode = null, string? 
            title = null, string? 
            type = null, 
            string? detail = null, 
            string? instance = null)
        {
            statusCode ??= 500;
            var problemDetails = new ProblemDetails
            {
                Status = statusCode, //You could delete these original property and only leave the Extensions property.
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };
            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
            return problemDetails;

        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            var validationproblemdetails = new ValidationProblemDetails
            {
                Status = statusCode,
            };
            return validationproblemdetails;
        }

        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            problemDetails.Extensions.Add("customproperty", "customvalue");
        }
    }
}
