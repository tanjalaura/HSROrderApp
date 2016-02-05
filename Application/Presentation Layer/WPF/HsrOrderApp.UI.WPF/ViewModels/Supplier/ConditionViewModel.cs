#region

using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.PresentationLogic;
using HsrOrderApp.UI.WPF.ViewModels.Base;

#endregion

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class ConditionViewModel : ListViewModelBase<SupplierConditionDTO>
    {
        public ConditionViewModel(SupplierDTO order)
            : base(order)
        {
        }

        protected override void LoadData()
        {
            foreach (SupplierConditionDTO orderDetail in ((SupplierDTO) ParentObject).Conditions)
                Items.Add(orderDetail);
        }

        protected override void New()
        {
            SupplierConditionDTO newSupplierCondition = new SupplierConditionDTO();
            ConditionDetailViewModel detailModelView = new ConditionDetailViewModel(newSupplierCondition, true);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                ParentObject.MarkChildForInsertion(newSupplierCondition);
                Items.Add(newSupplierCondition);
                SelectedItem = newSupplierCondition;
            }
        }

        protected override void Delete()
        {
            ParentObject.MarkChildForDeletion(SelectedItem);
            Items.Remove(SelectedItem);
        }

        protected override void Edit()
        {
            SupplierConditionDTO editCondition = SelectedItem.Clone();
            ConditionDetailViewModel detailModelView = new ConditionDetailViewModel(editCondition, false);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                int index = Items.IndexOf(SelectedItem);
                Items.Remove(SelectedItem);
                Items.Insert(index, editCondition);
                SelectedItem = editCondition;
                ParentObject.MarkChildForUpdate(editCondition);
            }
        }
    }
}