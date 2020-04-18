using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;
using System.Collections.Generic;

namespace RestWithASP_NET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
