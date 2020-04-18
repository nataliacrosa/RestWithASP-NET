using RestWithASP_NET.Data.Converter;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origem)
        {
            if (origem == null)
            {
                return new Book();
            }
            return new Book()
            {
                Id = origem.Id,
                Title = origem.Title,
                Author = origem.Author,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate
            };
        }

        public BookVO Parse(Book origem)
        {
            if (origem == null)
            {
                return new BookVO();
            }
            return new BookVO()
            {
                Id = origem.Id,
                Title = origem.Title,
                Author = origem.Author,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate
            };
        }

        public List<Book> ParseList(List<BookVO> origem)
        {
            if (origem == null)
            {
                return new List<Book>();
            }
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> ParseList(List<Book> origem)
        {
            if (origem == null)
            {
                return new List<BookVO>();
            }
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
