using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Common.Messages;

namespace Examples.Charge.API
{
    public class BaseController : ControllerBase
    {
        protected new ActionResult Response(BaseResponse response)
        {
            if (response == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(new
                {
                    success = true,
                    data = response
                });
            }
        }
    }
}
