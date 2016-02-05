#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Base;
using HsrOrderApp.SharedLibraries.SharedEnums;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO
{
    [DataContract]
    public class SupplierDTO : DTOParentObject
    {
        private string _accountNumber;
        private bool _activeFlag;
        private IList<AddressDTO> _addresses;
        private IList<SupplierConditionDTO> _conditions;
        private CreditRating _creditRating;
        private string _name;
        private bool _preferredSupplierFlag;
        private string _purchasingWebServiceURL;

        public SupplierDTO()
        {
            this.AccountNumber = string.Empty;
            this.Name = string.Empty;
            this.CreditRating = SharedEnums.CreditRating.Average;
            this.PreferredSupplierFlag = false;
            this.ActiveFlag = false;
            this.PurchasingWebServiceURL = string.Empty;
            this.Addresses = new List<AddressDTO>();
            this.Conditions = new List<SupplierConditionDTO>();
        }

        [DataMember]
        [StringLengthValidator(1, 15)]
        public string AccountNumber
        {
            get { return this._accountNumber; }
            set
            {
                if (value != _accountNumber)
                {
                    this._accountNumber = value;
                    OnPropertyChanged(() => AccountNumber);
                }
            }
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    this._name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        [DataMember]
        [NotNullValidator]
        public CreditRating CreditRating
        {
            get { return _creditRating; }
            set
            {
                if (value != _creditRating)
                {
                    this._creditRating = value;
                    OnPropertyChanged(() => CreditRating);
                }
            }
        }

        [DataMember]
        [NotNullValidator]
        public bool PreferredSupplierFlag
        {
            get { return this._preferredSupplierFlag; }
            set
            {
                if (value != _preferredSupplierFlag)
                {
                    this._preferredSupplierFlag = value;
                    OnPropertyChanged(() => PreferredSupplierFlag);
                }
            }
        }

        [DataMember]
        [NotNullValidator]
        public bool ActiveFlag
        {
            get { return this._activeFlag; }
            set
            {
                if (value != _activeFlag)
                {
                    this._activeFlag = value;
                    OnPropertyChanged(() => ActiveFlag);
                }
            }
        }

        [DataMember]
        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [StringLengthValidator(0, 1024)]
        public string PurchasingWebServiceURL
        {
            get { return _purchasingWebServiceURL; }
            set
            {
                string val = String.IsNullOrEmpty(value) ? null : value;
                if (val != _purchasingWebServiceURL)
                {
                    _purchasingWebServiceURL = val;
                    OnPropertyChanged(() => PurchasingWebServiceURL);
                }
            }
        }

        [DataMember]
        [ObjectCollectionValidator(typeof (AddressDTO))]
        public IList<AddressDTO> Addresses
        {
            get { return _addresses; }
            set
            {
                if (value != _addresses)
                {
                    this._addresses = value;
                    OnPropertyChanged(() => Addresses);
                }
            }
        }

        [DataMember]
        [ObjectCollectionValidator(typeof (SupplierConditionDTO))]
        public IList<SupplierConditionDTO> Conditions
        {
            get { return _conditions; }
            set
            {
                if (value != _conditions)
                {
                    this._conditions = value;
                    OnPropertyChanged(() => Conditions);
                }
            }
        }
    }
}