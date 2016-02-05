#region

using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.BusinessComponents;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using HsrOrderApp.BL.DTOAdapters.Helper;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.SharedLibraries.DTO.Base;

#endregion

namespace HsrOrderApp.BL.DtoAdapters
{
    public class SupplierAdapter
    {
        #region SupplierToDTO

        public static IList<SupplierListDTO> SuppliersToDtos(IQueryable<Supplier> suppliers)
        {
            IQueryable<SupplierListDTO> supplierDtos = from c in suppliers
                                                       select new SupplierListDTO()
                                                                  {
                                                                      Id = c.SupplierId,
                                                                      Name = c.Name,
                                                                      AccountNumber = c.AccountNumber,
                                                                      ActiveFlag = c.ActiveFlag,
                                                                      CreditRating = c.CreditRating,
                                                                      PreferredSupplierFlag = c.PreferredSupplierFlag
                                                                  };
            return supplierDtos.ToList();
        }

        public static SupplierDTO SupplierToDto(Supplier c)
        {
            SupplierDTO dto = new SupplierDTO()
                                  {
                                      Id = c.SupplierId,
                                      Name = c.Name,
                                      AccountNumber = c.AccountNumber,
                                      ActiveFlag = c.ActiveFlag,
                                      CreditRating = c.CreditRating,
                                      PreferredSupplierFlag = c.PreferredSupplierFlag,
                                      PurchasingWebServiceURL = c.PurchasingWebServiceURL,
                                      Version = c.Version,
                                      Addresses = AddressAdapter.AddressToDtos(c.Addresses),
                                      Conditions = ConditionsToDtos(c.Conditions)
                                  };

            return dto;
        }

        public static IList<SupplierConditionDTO> ConditionsToDtos(IQueryable<SupplierCondition> conditions)
        {
            IQueryable<SupplierConditionDTO> supplierConditionsDTOs = from c in conditions
                                                                      select ConditionToDto(c);
            return supplierConditionsDTOs.ToList();
        }

        public static SupplierConditionDTO ConditionToDto(SupplierCondition c)
        {
            SupplierConditionDTO dto = new SupplierConditionDTO()
                                           {
                                               Id = c.ConditionId,
                                               AverageLeadTime = c.AverageLeadTimeInDays,
                                               LastReceiptCost = c.LastReceiptCost,
                                               LastReceiptDate = c.LastReceiptDate,
                                               MaxOrderQuantity = c.MaxOrderQuantity,
                                               MinOrderQuantity = c.MinOrderQuantity,
                                               StandardPrice = c.StandardPrice,
                                               ProductId = c.Product.ProductId,
                                               ProductName = c.Product.Name,
                                               Version = c.Version
                                           };
            return dto;
        }

        #endregion

        #region DTOToSupplier

        public static Supplier DtoToSupplier(SupplierDTO dto)
        {
            Supplier supplier = new Supplier()
                                    {
                                        SupplierId = dto.Id,
                                        Name = dto.Name,
                                        AccountNumber = dto.AccountNumber,
                                        ActiveFlag = dto.ActiveFlag,
                                        CreditRating = dto.CreditRating,
                                        PreferredSupplierFlag = dto.PreferredSupplierFlag,
                                        PurchasingWebServiceURL = dto.PurchasingWebServiceURL,
                                        Version = dto.Version
                                    };
            ValidationHelper.Validate(supplier);
            return supplier;
        }

        public static IEnumerable<ChangeItem> GetChangeItems(SupplierDTO dto, Supplier supplier)
        {
            IEnumerable<ChangeItem> changeItems = from c in dto.Changes
                                                  select
                                                      new ChangeItem(c.ChangeType,
                                                                     DtoChildToBusinessChild(c.Object,
                                                                                             supplier));
            return changeItems;
        }

        private static DomainObject DtoChildToBusinessChild(DTOVersionObject dto, Supplier supplier)
        {
            if (dto is AddressDTO)
            {
                return AddressAdapter.DtoToAddress((AddressDTO) dto);
            }
            else if (dto is SupplierConditionDTO)
            {
                return DtoToCondition((SupplierConditionDTO) dto, supplier);
            }
            return null;
        }

        public static SupplierCondition DtoToCondition(SupplierConditionDTO dto, Supplier supplier)
        {
            SupplierCondition condition = new SupplierCondition
                                              {
                                                  ConditionId = dto.Id,
                                                  AverageLeadTimeInDays = dto.AverageLeadTime,
                                                  LastReceiptCost = dto.LastReceiptCost,
                                                  LastReceiptDate = dto.LastReceiptDate,
                                                  MaxOrderQuantity = dto.MaxOrderQuantity,
                                                  MinOrderQuantity = dto.MinOrderQuantity,
                                                  StandardPrice = dto.StandardPrice,
                                                  Supplier = supplier,
                                                  Version = dto.Version,
                                                  Product = new Product {ProductId = dto.ProductId}
                                              };

            ValidationHelper.Validate(condition);
            return condition;
        }

        #endregion
    }
}