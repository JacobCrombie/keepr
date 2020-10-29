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
        VaultKeep data = _vaultKeepRepo.FindByKeepId(newVaultKeep);
        if (data == null)
        {
        return _vaultKeepRepo.Create(newVaultKeep);
        }
        throw new Exception("Keep already in vault");
    }

    internal VaultKeep Delete(int id, string userInfoId)
    {
        VaultKeep data = _vaultKeepRepo.GetById(id);
        if(data == null)
        {
            throw new Exception("Invalid Id");
        }else if (data.CreatorId != userInfoId)
        {
            throw new Exception("Invalid Edit Permissions");
        }
        _vaultKeepRepo.Delete(id);
        return data;
    }
  }
}