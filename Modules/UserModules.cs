using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class UserModules {
     public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder usersRoutes = app.MapGroup("/users");

        usersRoutes.MapPost("/login", SignIn);
        usersRoutes.MapPost("/signup", SignUp);
    }
    static async Task<IResult> SignIn(Login login,UserDb db)
    {
        return TypedResults.Ok(await db
            .Queryable<User>(c => c.Mail == login.Mail && c.Password == login.Password)
            .FirstOrDefaultAsync());
    }

    static async Task<IResult> SignUp(NewUser user, UserDb db)
    {
        var userDb = new User{
            Name = user.Name,
            Mail = user.Mail,
            Password = user.Password
        };
        await db.Insertar<User>(userDb);
        
        db.SalvarCambios();
        // db.Get.Add(userDb);

        // await db.SaveChangesAsync();
        return TypedResults.Created($"/users/{userDb.Id}", user);
    }


}