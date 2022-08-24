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
    public class PasswordResetViewModel : ViewModelBase
    {
        public PasswordResetFormViewModel PasswordResetFormViewModel { get; }

        public PasswordResetViewModel(FirebaseAuthProvider firebaseAuthProvider, INavigationService loginNavigationService)
        {
            PasswordResetFormViewModel = new PasswordResetFormViewModel(firebaseAuthProvider, loginNavigationService);
        }
    }
}
