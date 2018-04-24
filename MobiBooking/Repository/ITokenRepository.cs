namespace MobiBooking.Models.Repository
{
    public interface ITokenRepository<Type>
    {
        Type GetLoginUser(string login, string password);
        Type Create(Type login);
    }
}