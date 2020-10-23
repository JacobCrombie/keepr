using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
      private readonly KeepsRepository _keepsRepo;

    public KeepsService(KeepsRepository keepsRepo)
    {
      _keepsRepo = keepsRepo;
    }

    internal IEnumerable<Keep> GetAll()
    {
      return _keepsRepo.GetAll();
    }

    internal Keep GetById(int id)
    {
        Keep data = _keepsRepo.GetById(id);
        if(data == null)
        {
            throw new Exception("Invalid Id");
        }
        return data;
    }
  }
}