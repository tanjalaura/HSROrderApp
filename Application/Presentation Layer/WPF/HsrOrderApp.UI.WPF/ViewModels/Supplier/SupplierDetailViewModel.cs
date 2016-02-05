#region

using System.Collections.Generic;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.SharedLibraries.SharedEnums;
using HsrOrderApp.UI.WPF.Converters;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;

#endregion

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierDetailViewModel : DetailViewModelBase<SupplierDTO>
    {
        #region Fields

        private AddressViewModel _addressListViewModel;
        private ConditionViewModel _conditionListViewModel;

        #endregion

        public SupplierDetailViewModel(SupplierDTO supplier, bool isNew)
            : base(supplier, isNew)
        {
            this.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
        }

        public AddressViewModel AddressListViewModel
        {
            get
            {
                if (this._addressListViewModel == null)
                {
                    this._addressListViewModel = new AddressViewModel(this.Model);
                    this._addressListViewModel.LoadCommand.Command.Execute(null);
                }
                return _addressListViewModel;
            }
        }

        public ConditionViewModel ConditionListViewModel
        {
            get
            {
                if (this._conditionListViewModel == null)
                {
                    this._conditionListViewModel = new ConditionViewModel(this.Model);
                    this._conditionListViewModel.LoadCommand.Command.Execute(null);
                }
                return _conditionListViewModel;
            }
        }

        protected override void SaveData()
        {
            Service.StoreSupplier(Model);
            SaveCommandExecuted();
        }

        #region Additional Datasources

        private List<NameValueItem> _creditRatings = null;

        public List<NameValueItem> CreditRatings
        {
            get
            {
                if (_creditRatings == null)
                {
                    _creditRatings = new List<NameValueItem>();
                    _creditRatings.Add(new NameValueItem(CreditRating.Superior, Strings.CreditRating_Superior));
                    _creditRatings.Add(new NameValueItem(CreditRating.Excellent, Strings.CreditRating_Excellent));
                    _creditRatings.Add(new NameValueItem(CreditRating.AboveAverage, Strings.CreditRating_AboveAverage));
                    _creditRatings.Add(new NameValueItem(CreditRating.Average, Strings.CreditRating_Average));
                    _creditRatings.Add(new NameValueItem(CreditRating.BelowAverage, Strings.CreditRating_BelowAverage));
                }
                return _creditRatings;
            }
        }

        #endregion
    }
}