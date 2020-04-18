using RestWithASP_NET.Data.Converter;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origem)
        {
            if (origem == null)
            {
                return new Person();
            }
            return new Person()
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null)
            {
                return new PersonVO();
            }
            return new PersonVO()
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<Person> ParseList(List<PersonVO> origem)
        {
            if (origem == null)
            {
                return new List<Person>();
            }
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origem)
        {
            if (origem == null)
            {
                return new List<PersonVO>();
            }
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
