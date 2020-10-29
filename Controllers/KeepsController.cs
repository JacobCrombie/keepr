using System;
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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsServ;
    public KeepsController(KeepsService keepsServ)
    {
      _keepsServ = keepsServ;
    }

    [HttpGet]
    public ActionResult<Keep> Get()
    {
      try
      {
        return Ok(_keepsServ.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        return Ok(_keepsServ.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        newKeep.Creator = userInfo;
        return Ok(_keepsServ.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //REVIEW might need to add more checks here if i impliment edit keep data instead of just counts
    [HttpPut("{id}/viewkeeps")]
    public ActionResult<Keep> EditViewKeeps([FromBody] Keep updatedKeep, int id)
    {
      try
      {
        updatedKeep.Id = id;
        return Ok(_keepsServ.EditViewKeeps(updatedKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Edit([FromBody] Keep updatedKeep, int id)
    {
      try
      {
          Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
          return Ok(_keepsServ.Edit(updatedKeep, userInfo.Id));
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
        return Ok(_keepsServ.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}