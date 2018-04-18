namespace MobiBooking.Models.Repository
{
    public interface ITokenRepository<Type>
    {
        Type Create(Type login);
    }
}