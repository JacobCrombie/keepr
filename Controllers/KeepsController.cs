using System;
using Keepr.Models;
using Keepr.Services;
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
  }
}