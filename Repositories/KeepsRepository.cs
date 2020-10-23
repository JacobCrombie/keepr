using System;
using System.Collections.Generic;
using System.Data;
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
  }
}