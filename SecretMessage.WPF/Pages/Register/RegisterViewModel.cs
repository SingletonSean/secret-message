using Firebase.Auth;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using SecretMessage.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretMessage.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterFormViewModel RegisterFormViewModel { get; }

        public RegisterViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            RegisterFormViewModel = new RegisterFormViewModel(firebaseAuthProvider, loginNavigationService);
        }
    }
}
