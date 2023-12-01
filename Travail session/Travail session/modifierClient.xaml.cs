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
using static System.Runtime.CompilerServices.RuntimeHelpers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    public sealed partial class ModifierClient : ContentDialog

    {
        clients c = null;
        public ModifierClient()
        {
            this.InitializeComponent();
        }

        public void SetClient(clients clients)
        {
            c = clients;
            tbxID.Text = Convert.ToString(c.Id);
            tbxNom.Text = Convert.ToString(c.Nom);
            tbxAdresse.Text = Convert.ToString(c.Adresse);
            tbxTelephone.Text = Convert.ToString(c.Telephone);
            tbxEmail.Text = Convert.ToString(c.Email);
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var erreur = false;
            if (string.IsNullOrEmpty(tbxNom.Text))
            {
                erreur = true;
                tbxNom.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxAdresse.Text))
            {
                erreur = true;
                tbxAdresse.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxTelephone.Text))
            {
                erreur = true;
                tbxTelephone.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxEmail.Text))
            {
                erreur = true;
                tbxEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (!erreur) Singleton.getInstance().modClient(new clients(c.Id, tbxNom.Text, tbxAdresse.Text, tbxEmail.Text, tbxTelephone.Text));
            else args.Cancel = true;

        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
