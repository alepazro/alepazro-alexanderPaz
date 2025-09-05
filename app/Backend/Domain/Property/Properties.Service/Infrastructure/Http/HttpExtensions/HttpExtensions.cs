namespace Properties.Service.Infrastructure.Http.HttpExtensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerDocumentation();

        }
    }
}
