using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vaultKeepServ;

    public VaultKeepsController(VaultKeepsService vaultKeepServ)
    {
      _vaultKeepServ = vaultKeepServ;
    }
    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
          return Ok(_vaultKeepServ.Create(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  [HttpDelete("{id}")]
    public ActionResult<VaultKeep> Delete(int id){
      try
      {
          return Ok(_vaultKeepServ.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}