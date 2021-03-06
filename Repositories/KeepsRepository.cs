using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _keepsDb;

    public KeepsRepository(IDbConnection keepsDb)
    {
      _keepsDb = keepsDb;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
        SELECT
        keep.*,
        prof.*
        FROM keeps keep
        JOIN profiles prof ON keep.creatorId = prof.id
        ";
      return _keepsDb.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = @"
        SELECT
        keep.*,
        prof.*
        FROM keeps keep
        JOIN profiles prof ON keep.creatorId = prof.id
        WHERE keep.id = @id
        ";
      return _keepsDb.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (creatorId, name, description, img, keeps, views, shares)
      VALUES
      (@CreatorId, @Name, @Description, @Img, @Keeps, @Views, @Shares);
      SELECT LAST_INSERT_ID();
      ";
      int id = _keepsDb.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT keep.*,
      vaultkeep.id AS VaultKeepId,
      prof.*
      FROM vaultkeeps vaultkeep
      JOIN keeps keep ON keep.id = vaultkeep.keepId
      JOIN profiles prof ON prof.id = keep.creatorId
      WHERE vaultId = @id;
      ";
      return _keepsDb.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id");
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string profileId)
    {
      string sql = @"
        SELECT
        keep.*,
        prof.*
        FROM keeps keep
        JOIN profiles prof ON keep.creatorId = prof.id
        WHERE keep.creatorId = @profileId;
      ";
      return _keepsDb.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { profileId }, splitOn: "id");
    }


    //FIXME need to return creator with mySQL request but cant figure out how sql docs are confusing
    internal Keep Edit(Keep updatedKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        views = @Views,
        keeps = @Keeps,
        shares = @Shares
      WHERE id = @Id;
      ";
      _keepsDb.Execute(sql, updatedKeep);
      return updatedKeep;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _keepsDb.Execute(sql, new { id });
    }
  }
}