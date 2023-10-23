 public static  class IoC
    {

        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrdersService, OrdersService>();

            return services;
        }
    }