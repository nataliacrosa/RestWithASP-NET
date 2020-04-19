using System.Collections.Generic;
using System.Text;
using RestWithASP_NET.Data.Converters;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASP_NET.Business.Implementattions
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var currentPage = page > 0 ? page : 1;
            page = page > 0 ? (page - 1) * pageSize : 0;

            var amountPersons = GetAmountPersons(name);

            var persons = GetPagedPersons(name, sortDirection, pageSize, page);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _converter.ParseList(persons),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = amountPersons
            };
        }

        private List<Person> GetPagedPersons(string name, string sortDirection, int pageSize, int page)
        {
            StringBuilder query = new StringBuilder(@" select * from persons p");
            if (!string.IsNullOrWhiteSpace(name))
            {
                query.AppendFormat(" where p.firstName like '%{0}%'", name);
            }
            query.AppendFormat(" order by p.firstName {0} limit {1} offset {2}", sortDirection, pageSize, page);

            var persons = _repository.FindWithPagedSearch(query.ToString());
            return persons;
        }

        private int GetAmountPersons(string name)
        {
            StringBuilder queryQuantidade = new StringBuilder(@" select * from persons p");
            if (!string.IsNullOrWhiteSpace(name))
            {
                queryQuantidade.AppendFormat(" where p.firstName like '%{0}%'", name);
            }

            var countQuery = _repository.GetCount(queryQuantidade.ToString());
            return countQuery;
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }
    }
}
