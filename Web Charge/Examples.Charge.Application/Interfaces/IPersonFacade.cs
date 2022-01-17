using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<bool> InsertPersonPhone(PersonPhoneDto personPhone);
        Task<bool> Delete(int id);
        Task<bool> Update(PersonPhoneDto personPhone);
    }
}