using Api.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Filters
{
    
    public class SwaggerAddAuthenticationHeaderFilter : IOperationFilter
    {
        void IOperationFilter.Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

                var isDefinedSign = context.MethodInfo.GetCustomAttributes(inherit: true)
                    .Any(a => a.GetType().Equals(typeof(SwaggerSignAttribute)));

                var isDefinedLang = context.MethodInfo.GetCustomAttributes(inherit: true)
                    .Any(a => a.GetType().Equals(typeof(LanguageAttribute)));

            if (isDefinedSign)
                AddSignParameter(operation);

            AddParameter(operation);

           
        }

        private void AddParameter(OpenApiOperation operation)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AuthenticationToken",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ExceprionLanguage",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });
        }

        private void AddSignParameter(OpenApiOperation operation)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AuthenticationToken",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "lang",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ts-cert",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ts-sign",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ts-sign-alg",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("")
                }
            });
        }
    }
}
