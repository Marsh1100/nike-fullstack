using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;

    private IBill _bills;
    private ICategory _categories;
    private IClient _clients;
    private IProduct _products;
    private ISale _sales;

  
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public IBill Bills
    {
        get
        {
            if (_bills == null)
            {
                _bills = new BillRepository(_context);
            }
            return _bills;
        }
    }
    public ICategory Categories
    {
        get
        {
            if (_categories == null)
            {
                _categories = new CategoryRepository(_context);
            }
            return _categories;
        }
    }
    public IClient Clients
    {
        get
        {
            if (_clients == null)
            {
                _clients = new ClientRepository(_context);
            }
            return _clients;
        }
    }
    public IProduct Products
    {
        get
        {
            if (_products == null)
            {
                _products = new ProductRepository(_context);
            }
            return _products;
        }
    }
    public ISale Sales
    {
        get
        {
            if (_sales == null)
            {
                _sales = new SaleRepository(_context);
            }
            return _sales;
        }
    }    
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}