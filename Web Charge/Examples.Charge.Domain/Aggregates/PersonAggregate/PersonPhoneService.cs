using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;

        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<bool> InsertPersonPhone(PersonPhone personPhone)
        {
            var result = await _personPhoneRepository.Insert(personPhone);
            return result != null;
        }

        public async Task<bool> Delete(int id)
        {
           return await _personPhoneRepository.Delete(id);
        }

        public async Task<bool> Update(PersonPhone personPhone)
        {
            return await _personPhoneRepository.Update(personPhone);
        }
    }
}