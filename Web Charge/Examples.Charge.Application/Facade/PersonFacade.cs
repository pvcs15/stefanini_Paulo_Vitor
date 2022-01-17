using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personService = personService;
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse
            {
                PersonObjects = new List<PersonDto>()
            };
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<bool> InsertPersonPhone(PersonPhoneDto personPhoneDto)
        {
            return await _personPhoneService.InsertPersonPhone(MapperPersonPhoneDto(personPhoneDto));
        }

        public async Task<bool> Delete(int id)
        {
            return await _personPhoneService.Delete(id);
        }

        public async Task<bool> Update(PersonPhoneDto personPhoneDto)
        {
            return await _personPhoneService.Update(MapperPersonPhoneDto(personPhoneDto));
        }

        //Para sistemas com muitas entidades(o que nao é o caso), utilizar automapper é bastante custoso para a inicialização no startup, sendo melhor não utilizar.
        private static PersonPhone MapperPersonPhoneDto(PersonPhoneDto personPhoneDto)
        {
            var personPhone = new PersonPhone
            {
                Person = personPhoneDto.Person,
                PhoneNumber = personPhoneDto.PhoneNumber,
                PhoneNumberType = personPhoneDto.PhoneNumberType,
                BusinessEntityID = personPhoneDto.BusinessEntityID,
                PhoneNumberTypeID = personPhoneDto.PhoneNumberTypeID
            };
            return personPhone;
        }
    }
}