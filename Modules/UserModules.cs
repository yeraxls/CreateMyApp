using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class UserModules {
     public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder usersRoutes = app.MapGroup("/users");

        usersRoutes.MapGet("/login", SignIn);
        usersRoutes.MapPost("/signup", SignUp);
    }
    static async Task<IResult> SignIn(UserDb db)
    {
        return TypedResults.Ok(await db.Get.ToListAsync());
    }

    static async Task<IResult> SignUp(NewUser user, UserDb db)
    {
        var userDb = new User{
            Name = user.Name,
            Mail = user.Mail,
            Password = user.Password
        };
        db.Get.Add(userDb);

        await db.SaveChangesAsync();
        return TypedResults.Created($"/users/{userDb.Id}", user);
    }


}