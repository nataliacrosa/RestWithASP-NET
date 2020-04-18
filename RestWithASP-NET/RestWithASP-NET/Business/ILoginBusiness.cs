using RestWithASP_NET.Model;

namespace RestWithASP_NET.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
