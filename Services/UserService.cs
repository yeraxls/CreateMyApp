using Microsoft.EntityFrameworkCore;

public class UserService : IUserService {
    private readonly UserDb _db;
    public UserService(UserDb db)
    {
        _db = db;
    }

    public async Task<User?> SignIn(Login login){
        return await _db.Queryable<User>(c => c.Mail == login.Mail && c.Password == login.Password)
                .FirstOrDefaultAsync();
    }
     public async Task<IResult> SignUp(NewUser user)
    {
            var checkIfExist = await _db.Queryable<User>(c => c.Mail == user.Mail).AnyAsync();
            if(checkIfExist) return TypedResults.NoContent();
            var userDb = new User
            {
                Name = user.Name,
                Mail = user.Mail,
                Password = user.Password
            };
            await _db.Insertar(userDb);

            _db.SalvarCambios();
            return TypedResults.Created($"/users/{userDb.Id}", user);
    }
     public async Task<IResult> ChangePassword(ChangePassword user)
    {
            var userDb = await _db.Queryable<User>(u => u.Mail == user.Mail && u.Password == user.OldPassword).FirstOrDefaultAsync();
            if (userDb is null) return TypedResults.NotFound();

            userDb.Password = user.NewPassword;

            _db.SalvarCambios();

            return TypedResults.Created($"/users/{userDb.Id}", user);
    }
}
