using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<bool> InsertPersonPhone(PersonPhone personPhone);
        Task<bool> Delete(int id);
        Task<bool> Update(PersonPhone personPhone);
    }
}
