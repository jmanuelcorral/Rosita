using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rosita.Core.Framework;
using Rosita.Core.Framework.Criterias;
using Rosita.Invoice.Core.Boundaries.GetInvoice;

namespace Rosita.Invoice.API.Service.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse> _getByCodeUseCase;

        public InvoiceController(UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse> getByCodeUseCase)
        {
            _getByCodeUseCase = getByCodeUseCase;
        }
        // GET api/invoices
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Invoice/5
        [HttpGet]
        [Route("/api/[controller]/Code/{code}")]
        public async Task<IActionResult> code(string code)
        {
            var response = await _getByCodeUseCase.Handle(new GetInvoiceByCodeRequest(new SimpleUseCaseRequestCriteria(CriteriaType.Equal))
            {
                InvoiceCode = code
            });
            if (response.Status == UseCaseResponseStatus.Found) return Ok(response.Result);
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
