public static class Modules {
     public static void AddRoutes(this WebApplication app)
    {
        UserModules.AddRoutes(app);
        OrdersModules.AddRoutes(app);
    }

}