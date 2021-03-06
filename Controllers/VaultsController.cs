using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultServ;
    private readonly KeepsService _keepServ;

    public VaultsController(VaultsService vaultServ, KeepsService keepServ)
    {
      _vaultServ = vaultServ;
      _keepServ = keepServ;
    }

    [HttpGet]
    public ActionResult<Vault> Get()
    {
      try
      {
        return Ok(_vaultServ.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetById(int id)
    {
      try
      {
        Profile userInfo = null;
        try
        {
          userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        }
        catch (System.Exception)
        {
          Console.WriteLine("no profile");
        }
        return Ok(_vaultServ.GetById(id, userInfo?.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeeps(int id)
    {
      try
      {
        Profile userInfo = null;
        try
        {
          userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        }
        catch (System.Exception)
        {
          Console.WriteLine("no profile");
        }
        return Ok(_keepServ.GetKeepsByVaultId(id, userInfo?.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        newVault.Creator = userInfo;
        return Ok(_vaultServ.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit([FromBody] Vault updatedVault, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updatedVault.Id = id;
        return Ok(_vaultServ.Edit(updatedVault, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vaultServ.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}