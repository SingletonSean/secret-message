using SecretMessage.WPF.Shared.ViewModels;

namespace SecretMessage.WPF.Shared.Navigation
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { set; }
    }
}