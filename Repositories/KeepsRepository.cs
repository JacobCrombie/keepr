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
        SELECT * FROM keeps;
        ";
      return _keepsDb.Query<Keep>(sql);
    }

    internal Keep GetById(int id)
    {
        string sql = @"
        SELECT * FROM keeps WHERE id = @id;
        ";
        return _keepsDb.Query<Keep>(sql, new {id}).FirstOrDefault();
    }
  }
}