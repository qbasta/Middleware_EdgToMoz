namespace Middleware_EdgToMoz
{
    public class UrlTransform
    {
        private RequestDelegate _next;

        public UrlTransform(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var r = context.Request.Headers["User-Agent"].ToString();

            if (r.Contains("Edg"))
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }

            return _next(context);
        }

    }

    public static class UrlTransformMiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlTransformMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UrlTransform>();
        }
    }
}
