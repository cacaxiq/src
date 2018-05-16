using Base.ViewModel.Base;
using ReactiveUI.XamForms;

namespace Base.Mobile.CrossPresentation.Base
{
    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel>
      where TViewModel : ViewModelBase
    { }
}
