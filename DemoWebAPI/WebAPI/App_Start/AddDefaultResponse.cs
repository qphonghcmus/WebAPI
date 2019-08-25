using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace WebAPI
{
    /// <summary>
    /// Thêm một ô nhập tham số trong file header khi test trên Swagger UI (Swashbuckle)
    /// </summary>
    internal class AddDefaultResponse : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter()
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                description = "Basic Authentication",
                required = false
            });
        }
    }
}