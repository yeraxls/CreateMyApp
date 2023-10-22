public interface IUserService{
    public Task<User?> SignIn(Login login);
    Task<IResult> SignUp(NewUser user);
    Task<IResult> ChangePassword(ChangePassword user);
}