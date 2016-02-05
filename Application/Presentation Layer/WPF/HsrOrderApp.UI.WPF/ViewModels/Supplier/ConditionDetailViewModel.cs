#region

using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;

#endregion

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class ConditionDetailViewModel : DetailViewModelBase<SupplierConditionDTO>
    {
        private string _estimatedDeliveryTime;
        private IList<ProductDTO> _products;

        public ConditionDetailViewModel(SupplierConditionDTO orderDetail, bool isNew)
            : base(orderDetail, isNew)
        {
            this.DisplayName = Strings.ConditionDetailViewModel_DisplayName;
        }

        public int ProductId
        {
            get { return this.Model.ProductId; }
            set
            {
                if (this.Model.ProductId != value)
                {
                    SendPropertyChanging("ProductId");
                    ProductDTO pdto = Products.First(p => p.Id == value);
                    this.Model.ProductId = value;
                    this.Model.ProductName = pdto.Name;
                    SendPropertyChanged("ProductId");
                }
            }
        }

        public IList<ProductDTO> Products
        {
            get
            {
                if (_products == null)
                    _products = Service.GetAllProducts();
                return _products;
            }
        }

        #endregion
    }
}