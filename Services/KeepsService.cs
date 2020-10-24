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
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Keep Create(Keep newKeep)
    {
      return _keepsRepo.Create(newKeep);
    }

    internal Keep Edit(Keep updatedKeep)
    {
      Keep data = GetById(updatedKeep.Id);
      updatedKeep.CreatorId = data.CreatorId;
      updatedKeep.Description = data.Description;
      updatedKeep.Name = data.Name;
      updatedKeep.Id = data.Id;
      updatedKeep.Img = data.Img;
      updatedKeep.Keeps = updatedKeep.Keeps != 0 ? updatedKeep.Keeps : data.Keeps;
      updatedKeep.Views = updatedKeep.Views != 0 ? updatedKeep.Views : data.Views;
      updatedKeep.Shares = updatedKeep.Shares != 0 ? updatedKeep.Shares : data.Shares;
      return _keepsRepo.Edit(updatedKeep);
    }
  }
}