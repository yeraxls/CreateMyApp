using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class UserModules
{
    public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder usersRoutes = app.MapGroup("/users");

        usersRoutes.MapPost("/login", SignIn);
        usersRoutes.MapPost("/signup", SignUp);
        usersRoutes.MapPost("/changepassword", ChangePassword);
    }
    static async Task<IResult> SignIn(Login login, UserDb db)
    {
        try
        {
            return TypedResults.Ok(await db
                .Queryable<User>(c => c.Mail == login.Mail && c.Password == login.Password)
                .FirstOrDefaultAsync());
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> SignUp(NewUser user, UserDb db)
    {
        try
        {
            var checkIfExist = await db.Queryable<User>(c => c.Mail == user.Mail).AnyAsync();
            if(checkIfExist) return TypedResults.NoContent();
            var userDb = new User
            {
                Name = user.Name,
                Mail = user.Mail,
                Password = user.Password
            };
            await db.Insertar(userDb);

            db.SalvarCambios();
            return TypedResults.Created($"/users/{userDb.Id}", user);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> ChangePassword(ChangePassword user, UserDb db)
    {
        try
        {
            var userDb = await db.Queryable<User>(u => u.Mail == user.Mail && u.Password == user.OldPassword).FirstOrDefaultAsync();
            if (userDb is null) return TypedResults.NotFound();

            userDb.Password = user.NewPassword;

            db.SalvarCambios();

            return TypedResults.Created($"/users/{userDb.Id}", user);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
}