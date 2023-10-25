using Microsoft.EntityFrameworkCore;

public static class IoC
{

    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IOrdersService, OrdersService>();

        return services;
    }

    public static IServiceCollection AddDBContexts(this IServiceCollection services)
    {
        services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("Users"));
        services.AddDbContext<OrderDb>(opt => opt.UseInMemoryDatabase("Orders"));

        return services;
    }

}