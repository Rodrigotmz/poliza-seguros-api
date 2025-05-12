using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.EFcontexts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Entities.DTOs;
using Helpers;

namespace poliza_seguro_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoliciesController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "AdminOrBroker")]
        [HttpGet("allpoliciestype")]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPoliciesByType(string? type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                try
                {
                    return await _context.Policies.Where(p => p.Status.ToLower().Equals(type.ToLower())).ToListAsync();
                }
                catch
                {
                    return await _context.Policies.ToListAsync();
                }

            }
            return await _context.Policies.ToListAsync();
        }

        [Authorize(Policy = "AdminOrBroker")]
        [HttpGet("allpolicies")]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        // GET: api/Policies/5
        [HttpGet("mypolicies")]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicy(long id)
        {
            try
            {
                var policy = await _context.Policies.Where(poli => poli.ClientId == id).ToListAsync();

                if (policy == null)
                {
                    return NotFound();
                }
                return policy;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las polizas", error = ex.Message });
            }

        }
        [Authorize(Policy = "AdminOrBroker")]
        [HttpPut("updatepolicy")]
        public async Task<IActionResult> PutPolicy(long id, [FromBody] UpdatePolicyDTO policy)
        {
            if (id != policy.Id)
            {
                return BadRequest();
            }
            var policyToUpdate = await _context.Policies.FindAsync(id);
            if (policyToUpdate == null)
            {
                return NotFound();
            }
            policyToUpdate.Status = policy.Status;
            _context.Entry(policyToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Poliza actualizada con exito." });
        }

        [HttpPost("newpolicie")]
        public async Task<IActionResult> PostPolicy(CreatePolicyDTO policy)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existingClient = await _context.Clients
                    .FirstOrDefaultAsync(p => p.Curp == policy.Client.Curp);

                if (existingClient == null)
                {
                    var client = PolicyFactory.CreateNewClient(policy);
                    var newPolicyWithClient = PolicyFactory.CreateNewPolicy(policy, client);
                    _context.Policies.Add(newPolicyWithClient);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetPolicy", new { id = policy.Id }, policy);
                }
                var newPolicy = PolicyFactory.CreateNewPolicy(policy, existingClient);
                _context.Policies.Add(newPolicy);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPolicy", new { message = $"Se creo con exito la poliza. No. de Poliza {newPolicy.PolicyNumber}" });
            }
            catch
            {
                return BadRequest(new { message = "Error al crear la poliza" });
            }
        }

        //DELETE: api/Policies/5
        //    [HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePolicy(long id)
        //{
        //    var policy = await _context.Policies.FindAsync(id);
        //    if (policy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Policies.Remove(policy);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PolicyExists(long id)
        {
            return _context.Policies.Any(e => e.Id == id);
        }

    }
}
