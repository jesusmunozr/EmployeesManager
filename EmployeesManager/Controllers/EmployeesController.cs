using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesManager.Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeBl _employeeBl;

        public EmployeesController(IEmployeeBl employeeBl)
        {
            this._employeeBl = employeeBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._employeeBl.Get(null);

            if(result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this._employeeBl.Get(id);

            if(result is null)
            {
                return this.NotFound(id);
            }

            return this.Ok(result);
        }
    }
}