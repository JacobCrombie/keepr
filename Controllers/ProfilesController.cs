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
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _keepsServ;

    public ProfilesController(ProfilesService ps, KeepsService keepsServ)
    {
      _ps = ps;
      _keepsServ = keepsServ;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByProfile(string id)
    {
      try
      {
        Profile queryProfile = _ps.GetProfileById(id);
        return Ok(_keepsServ.GetKeepsByProfile(queryProfile.Id));

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}