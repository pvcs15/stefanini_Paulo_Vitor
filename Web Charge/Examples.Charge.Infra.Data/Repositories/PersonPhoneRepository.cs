using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);
        
        public async Task<PersonPhone> Insert(PersonPhone personPhone)
        {
            await _context.PersonPhone.AddAsync(personPhone);
            await _context.SaveChangesAsync();
            return personPhone;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _context.PersonPhone.FindAsync(id);
            if (model == null)
            {
                return false;
            }

            _context.PersonPhone.Remove(model);
            return true;
        }

        public async Task<bool> Update(PersonPhone personPhone)
        {
            var model = await _context.PersonPhone.FindAsync(personPhone.BusinessEntityID);
            if (model == null)
            {
                return false;
            }
            _context.PersonPhone.Update(personPhone);
            return true;
        }
    }
}
