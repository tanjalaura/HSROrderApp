#region

using System;
using HsrOrderApp.BL.DomainModel.HelperObjects;
using HsrOrderApp.BL.DomainModel.SpecialCases;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.BL.DomainModel
{
    public class SupplierCondition : DomainObject
    {
        public SupplierCondition()
        {
            this.ConditionId = default(int);
            this.Supplier = new UnknownSupplier();
            this.Product = new UnknownProduct();
            this.AverageLeadTimeInDays = default(int);
            this.StandardPrice = default(decimal);
            this.LastReceiptCost = null;
            this.LastReceiptDate = null;
            this.MinOrderQuantity = 0;
            this.MaxOrderQuantity = 0;
        }

        [NotNullValidator]
        public int ConditionId { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }

        [RangeValidator(0, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int AverageLeadTimeInDays { get; set; }

        [RangeValidator(typeof (decimal), "0.0", RangeBoundaryType.Inclusive, "0.0", RangeBoundaryType.Ignore)]
        public decimal StandardPrice { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(typeof (decimal), "0.0", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore)]
        public decimal? LastReceiptCost { get; set; }

        public DateTime? LastReceiptDate { get; set; }

        [RangeValidator(0, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MinOrderQuantity { get; set; }

        [RangeValidator(0, RangeBoundaryType.Exclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MaxOrderQuantity { get; set; }
    }
}