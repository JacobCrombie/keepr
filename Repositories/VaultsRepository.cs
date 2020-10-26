using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _vaultsDb;

    public VaultsRepository(IDbConnection vaultsDb)
    {
      _vaultsDb = vaultsDb;
    }

    internal IEnumerable<Vault> GetAll()
    {
      string sql = @"
        SELECT
        vault.*,
        prof.*
        FROM vaults vault
        JOIN profiles prof ON vault.creatorId = prof.id
        ";
      return _vaultsDb.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, splitOn: "id");
    }

    internal IEnumerable<Vault> GetVaultsByProfile(string profid)
    {
      string sql = @"
        SELECT
        vault.*,
        prof.*
        FROM vaults vault
        JOIN profiles prof ON vault.creatorId = prof.id
        WHERE vault.creatorId = @profid;
      ";
      return _vaultsDb.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { profid }, splitOn: "id");
    }

    internal Vault GetById(int id)
    {
      string sql = @"
        SELECT
        vault.*,
        prof.*
        FROM vaults vault
        JOIN profiles prof ON vault.creatorId = prof.id
        Where vault.id = @id
        ";
      return _vaultsDb.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
        INSERT INTO vaults
        (creatorId, name, description, isprivate)
        VALUES
        (@CreatorId, @Name, @Description, @IsPrivate);
        SELECT LAST_INSERT_ID();
        ";
      int id = _vaultsDb.ExecuteScalar<int>(sql, newVault);
      newVault.Id = id;
      return newVault;
    }

    internal Vault Edit(Vault updatedVault)
    {
      string sql = @"
        UPDATE vaults
        SET
          name = @Name,
          description = @Description,
          isprivate = @IsPrivate
        WHERE id = @Id;
        ";
      _vaultsDb.Execute(sql, updatedVault);
      return updatedVault;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id";
      _vaultsDb.Execute(sql, new { id });
    }
  }
}