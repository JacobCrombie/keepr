using System;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
      private readonly IDbConnection _vaultKeepDb;

    public VaultKeepsRepository(IDbConnection vaultKeepDb)
    {
      _vaultKeepDb = vaultKeepDb;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
        string sql = @"
        INSERT INTO vaultkeeps
        (keepId, vaultId, creatorId)
        VALUES
        (@KeepId, @VaultId, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
        int id =_vaultKeepDb.ExecuteScalar<int>(sql, newVaultKeep);
        newVaultKeep.Id = id;
        return newVaultKeep;
    }
    internal VaultKeep FindByKeepId(VaultKeep newVaultKeep)
    {
      string sql = @"
      SELECT * FROM vaultkeeps
       WHERE keepid = @KeepId
       AND vaultid = @VaultId;
      ";
      return _vaultKeepDb.Query<VaultKeep>(sql, new{KeepId = newVaultKeep.KeepId, VaultId = newVaultKeep.VaultId}).FirstOrDefault();
    }

    internal void Delete(int id)
    {
        string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1;";
        _vaultKeepDb.Execute(sql, new{id});
    }

    internal VaultKeep GetById(int id)
    {
        string sql = "SELECT * FROM vaultkeeps WHERE id = @Id;";
        return _vaultKeepDb.QueryFirstOrDefault<VaultKeep>(sql, new {id});
    }
  }
}