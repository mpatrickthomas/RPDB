using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPDB.Data;
using RPDB.Data.Entities;

namespace RPDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController: ControllerBase {
        public IRPDBRepository Repository{ get; }
        
        public SeasonsController(IRPDBRepository repo)
        {
            this.Repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeasons(){
            return await this.Repository.GetAllSeasons();
        }


    }
}