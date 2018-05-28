using Base.Mobile.CrossPresentation.Custom.Renders;
using Base.ViewModel.Base;
using ReactiveUI;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;

namespace Base.Mobile.CrossPresentation.Base
{
    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel>
      where TViewModel : ViewModelBase
    {
    }
}
