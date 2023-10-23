public static class UserModules
{
    public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder usersRoutes = app.MapGroup("/users");

        usersRoutes.MapPost("/login", SignIn);
        usersRoutes.MapPost("/signup", SignUp);
        usersRoutes.MapPost("/changepassword", ChangePassword);
    }
    static async Task<IResult> SignIn(Login login, IUserService userService)
    {
        try
        {
            return TypedResults.Ok(await userService.SignIn(login));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> SignUp(NewUser user, IUserService userService)
    {
        try
        {
            return await userService.SignUp(user);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> ChangePassword(ChangePassword user, IUserService userService)
    {
        try
        {
           return await userService.ChangePassword(user);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
}