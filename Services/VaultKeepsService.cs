using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _vaultKeepRepo;

    public VaultKeepsService(VaultKeepsRepository vaultKeepRepo)
    {
      _vaultKeepRepo = vaultKeepRepo;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
        return _vaultKeepRepo.Create(newVaultKeep);
    }

    internal VaultKeep Delete(int id)
    {
        VaultKeep data = _vaultKeepRepo.GetById(id);
        if(data == null)
        {
            throw new Exception("Invalid Id");
        }
        _vaultKeepRepo.Delete(id);
        return data;
    }
  }
}