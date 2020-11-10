using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepo;
    private readonly VaultsRepository _vaultsRepo;

    public KeepsService(KeepsRepository keepsRepo, VaultsRepository vaultsRepo)
    {
      _keepsRepo = keepsRepo;
      _vaultsRepo = vaultsRepo;
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

    internal Keep EditViewKeeps(Keep updatedKeep)
    {
      Keep data = GetById(updatedKeep.Id);
      updatedKeep.Description = data.Description;
      updatedKeep.Name = data.Name;
      updatedKeep.Img = data.Img;
      updatedKeep.Keeps = updatedKeep.Keeps != 0 ? updatedKeep.Keeps : data.Keeps;
      updatedKeep.Views = updatedKeep.Views != 0 ? updatedKeep.Views : data.Views;
      updatedKeep.Shares = updatedKeep.Shares != 0 ? updatedKeep.Shares : data.Shares;
      return _keepsRepo.Edit(updatedKeep);
    }
    internal object Edit(Keep updatedKeep, string id)
    {
      Keep data = GetById(updatedKeep.Id);
      if (data.CreatorId != id)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      updatedKeep.Description = updatedKeep.Description != null ? updatedKeep.Description : data.Description;
      updatedKeep.Name = updatedKeep.Name != null ? updatedKeep.Name : data.Name;
      updatedKeep.Img = updatedKeep.Img != null ? updatedKeep.Img : data.Img;
      updatedKeep.Keeps = updatedKeep.Keeps != 0 ? updatedKeep.Keeps : data.Keeps;
      updatedKeep.Views = updatedKeep.Views != 0 ? updatedKeep.Views : data.Views;
      updatedKeep.Shares = updatedKeep.Shares != 0 ? updatedKeep.Shares : data.Shares;
      return _keepsRepo.Edit(updatedKeep);
    }

    // FIXME lkjadl;sfjla;dsfkja add creator check
    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, string userInfoId)
    {
      Vault data = _vaultsRepo.GetById(id);
      if (data.CreatorId != userInfoId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      return _keepsRepo.GetKeepsByVaultId(id);
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string profId)
    {
      return _keepsRepo.GetKeepsByProfile(profId);
    }

    internal string Delete(int id, string userId)
    {
      Keep data = GetById(id);
      if (data.CreatorId != userId)
      {
        throw new Exception("Invalid Edit Permissions, This keep isn't yours to delete");
      }
      _keepsRepo.Delete(id);
      return "Keep Removed";
    }

  }
}