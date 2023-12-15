using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    public sealed partial class assignationEmp : ContentDialog
    {
        public assignationEmp()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var erreur = false;

            //if (string.IsNullOrEmpty(tbxNom.Text))
            //{
            //    erreur = true;
            //    tbxNom.BorderBrush = new SolidColorBrush(Colors.Red);
            //}
           
            //if (!erreur) Singleton.getInstance().modEmploye(new employes(tbxMat.Text, tbxNom.Text, tbxPrenom.Text, tbxNaissance.Text, tbxEmail.Text, tbxAdresse.Text, tbxEmbauche.Text, Convert.ToDouble(tbxTaux.Text), tbxPhoto.Text, (string)cbStatut.SelectedValue));
            //else args.Cancel = true;


        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
