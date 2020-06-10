using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPDB.Data;
using RPDB.Data.Entities;

namespace RPDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueensController : ControllerBase
    {
        public IRPDBRepository Repository { get; }

        public QueensController(IRPDBRepository repository)
        {
            this.Repository = repository;
        }

        // GET: api/Queens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Queen>>> GetQueens()
        {
            //Thread.Sleep(5 * 1000);
            var queens = await this.Repository.GetAllQueens();
            return queens;
        }

        // GET: api/Queens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Queen>> GetQueen(int id)
        {
            var queen = await this.Repository.GetQueenById(id);

            if (queen == null)
            {
                return NotFound();
            }

            return Ok(queen);
        }

        // PUT: api/Queens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueen(int id, Queen queen)
        {
            if (id != queen.QueenId)
            {
                return BadRequest();
            }

            if(! await this.Repository.ModifyQueen(id, queen))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Queens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Queen>> PostQueen(Queen queen)
        {
            await this.Repository.AddQueen(queen);

            return CreatedAtAction("GetQueen", new { id = queen.QueenId }, queen);
        }

        // DELETE: api/Queens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Queen>> DeleteQueen(int id)
        {
            var queen = await this.Repository.GetQueenById(id);
            if (queen == null)
            {
                return NotFound();
            }

            await this.Repository.DeleteQueen(queen);

            return queen;
        }


    }
}
