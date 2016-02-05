#region

using System;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierConditionDTO : DTOVersionObject
    {
        private int _averageLeadTime;
        private decimal? _lastReceiptCost;
        private DateTime? _lastReceiptDate;
        private int _maxOrderQuantity;
        private int _minOrderQuantity;
        private int _productId;
        private string _productName;
        private decimal _standardPrice;

        public SupplierConditionDTO()
        {
            this.Id = default(int);
            this.ProductName = string.Empty;
            this.AverageLeadTime = default(int);
            this.StandardPrice = default(decimal);
            this.LastReceiptDate = null;
            this.LastReceiptCost = null;
            this.MinOrderQuantity = default(int);
            this.MaxOrderQuantity = 999999;
        }

        [DataMember]
        [NotNullValidator]
        public int ProductId
        {
            get { return this._productId; }
            set
            {
                if (value != _productId)
                {
                    this._productId = value;
                    OnPropertyChanged(() => Id);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value != _productName)
                {
                    this._productName = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }

        [DataMember]
        [RangeValidator(0, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int AverageLeadTime
        {
            get { return _averageLeadTime; }
            set
            {
                if (value != _averageLeadTime)
                {
                    this._averageLeadTime = value;
                    OnPropertyChanged(() => AverageLeadTime);
                }
            }
        }

        [DataMember]
        [RangeValidator(typeof (decimal), "0.0", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore)]
        public decimal StandardPrice
        {
            get { return _standardPrice; }
            set
            {
                if (value != _standardPrice)
                {
                    this._standardPrice = value;
                    OnPropertyChanged(() => _standardPrice);
                }
            }
        }

        [DataMember]
        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(typeof (decimal), "0.0", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore)]
        public decimal? LastReceiptCost
        {
            get { return _lastReceiptCost; }
            set
            {
                if (value != _lastReceiptCost)
                {
                    this._lastReceiptCost = value;
                    OnPropertyChanged(() => LastReceiptCost);
                }
            }
        }

        [DataMember]
        public DateTime? LastReceiptDate
        {
            get { return _lastReceiptDate; }
            set
            {
                if (value != _lastReceiptDate)
                {
                    this._lastReceiptDate = value;
                    OnPropertyChanged(() => LastReceiptDate);
                }
            }
        }

        [DataMember]
        [RangeValidator(0, RangeBoundaryType.Inclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MinOrderQuantity
        {
            get { return _minOrderQuantity; }
            set
            {
                if (value != _minOrderQuantity)
                {
                    this._minOrderQuantity = value;
                    OnPropertyChanged(() => MinOrderQuantity);
                }
            }
        }

        [DataMember]
        [RangeValidator(0, RangeBoundaryType.Exclusive, int.MaxValue, RangeBoundaryType.Ignore)]
        public int MaxOrderQuantity
        {
            get { return _maxOrderQuantity; }
            set
            {
                if (value != _maxOrderQuantity)
                {
                    this._maxOrderQuantity = value;
                    OnPropertyChanged(() => MaxOrderQuantity);
                }
            }
        }
    }
}