using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnionDemo.Application.Helpers;

namespace OnionDemo.Infrastructure;

public class UnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private readonly DbContext _db;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(T db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_db.Database.CurrentTransaction != null) return;
        _transaction = _db.Database.BeginTransaction(isolationLevel);
    }

    void IUnitOfWork.Commit()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Commit is called");
        try
        {
            _db.SaveChanges();
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    void IUnitOfWork.Rollback()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Rollback is called");

        try
        {
            _transaction.Rollback();
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }
}