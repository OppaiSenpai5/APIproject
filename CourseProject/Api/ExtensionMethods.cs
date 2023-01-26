namespace Api
{
    using Service.Repositories.Interfaces;
    using Service.Repositories;
    using Service.Services.Interfaces;
    using Service.Services;

    public static class ExtensionMethods
    {
        public static IServiceCollection AddCustomServices(
            this IServiceCollection services) => 
            services
                .AddScoped<IAnimeRepository, AnimeRepository>()
                .AddScoped<IAnimeService, AnimeService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserAnimeRepository, UserAnimeRepository>()
                .AddScoped<IUserAnimeService, UserAnimeService>()
                .AddScoped<IPdfService, PdfService>();
    }
}
