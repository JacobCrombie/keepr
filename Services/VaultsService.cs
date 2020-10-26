using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepo;

    public VaultsService(VaultsRepository vaultsRepo)
    {
      _vaultsRepo = vaultsRepo;
    }

    internal IEnumerable<Vault> GetAll()
    {
      return _vaultsRepo.GetAll();
    }
    internal IEnumerable<Vault> GetVaultsByProfile(string profid)
    {
        return _vaultsRepo.GetVaultsByProfile(profid);
    }

    internal Vault GetById(int id)
    {
      Vault data = _vaultsRepo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Vault Create(Vault newVault)
    {
      return _vaultsRepo.Create(newVault);
    }

    internal Vault Edit(Vault updatedVault, string userId)
    {
      Vault data = GetById(updatedVault.Id);
      if (data.CreatorId != userId)
      {
        throw new Exception("Invalid Edit Permissions, This Vault isn't yours to Edit");
      }
      updatedVault.Name = updatedVault.Name != null ? updatedVault.Name :data.Name;
      updatedVault.Description = updatedVault.Description != null ? updatedVault.Description : data.Description;
      return _vaultsRepo.Edit(updatedVault);
    }

    internal string Delete(int id, string userId)
    {
        Vault data = GetById(id);
        if (data.CreatorId != userId)
        {
            throw new Exception("Invalid Edit Permissions, This Vault isn't yours to delete.");
        }
         _vaultsRepo.Delete(id);
         return "Vault Removed;";
    }

  }
}