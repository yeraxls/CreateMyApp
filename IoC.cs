 public static  class IoC
    {

        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }