using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacion;
using CapaDominio.Contracts;
using CapaInfraestructura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        readonly CreditoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public CreditoController(CreditoContext context, IUnitOfWork unitofWorck)
        {
            _context = context;
            _unitOfWork = unitofWorck;
        }

        [HttpPost]
        public ActionResult<RegistrarCredito> Post(AgregarCreditoRequest request)
        {
            RegistrarCredito _service = new RegistrarCredito(_unitOfWork);
            AgregarCreditoResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

    }
}