using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<PersonPhone> Insert(PersonPhone personPhone);
        Task<bool> Delete(int id);
        Task<bool> Update(PersonPhone personPhone);
    }
}
