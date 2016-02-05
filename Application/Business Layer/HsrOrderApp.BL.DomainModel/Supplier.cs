#region

using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using HsrOrderApp.SharedLibraries.SharedEnums;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.BL.DomainModel
{
    public class Supplier : DomainObject
    {
        public Supplier()
        {
            this.SupplierId = default(int);
            this.AccountNumber = string.Empty;
            this.Name = string.Empty;
            this.CreditRating = CreditRating.Average;
            this.PreferredSupplierFlag = false;
            this.ActiveFlag = false;
            this.PurchasingWebServiceURL = string.Empty;

            this.Addresses = new List<Address>().AsQueryable();
            this.Conditions = new List<SupplierCondition>().AsQueryable();
        }

        public int SupplierId { get; set; }

        [StringLengthValidator(1, 15)]
        public string AccountNumber { get; set; }

        [StringLengthValidator(1, 50)]
        public string Name { get; set; }

        public CreditRating CreditRating { get; set; }

        public bool PreferredSupplierFlag { get; set; }
        public bool ActiveFlag { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [StringLengthValidator(0, 1024)]
        public string PurchasingWebServiceURL { get; set; }

        public IQueryable<Address> Addresses { get; set; }
        public IQueryable<SupplierCondition> Conditions { get; set; }
    }
}