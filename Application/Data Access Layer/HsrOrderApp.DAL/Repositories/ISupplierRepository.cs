﻿#region

using System.Linq;
using HsrOrderApp.BL.DomainModel;

#endregion

namespace HsrOrderApp.DAL.Data.Repositories
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> GetAll();
        Supplier GetById(int id);

        int SaveSupplier(Supplier supplier);
        int SaveCondition(SupplierCondition condition, Supplier forThisSupplier);
        int SaveAddress(Address address, Supplier forThisSupplier);

        void DeleteSupplier(int id);
        void DeleteCondition(int id);
        void DeleteAddress(int id);
    }
}