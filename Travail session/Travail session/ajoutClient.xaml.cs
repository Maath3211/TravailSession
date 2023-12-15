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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ajoutClient : Page
    {
        public ajoutClient()
        {
            this.InitializeComponent();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
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
            if (string.IsNullOrEmpty(tbxEmail.Text))
            {
                erreur = true;
                tbxEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxTelephone.Text))
            {
                erreur = true;
                tbxTelephone.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (!erreur)
            {
                clients c = new clients(0, tbxNom.Text, tbxAdresse.Text, tbxEmail.Text, tbxTelephone.Text);
                Singleton.getInstance().ajouterClient(c);
                Frame.Navigate(typeof(affichage_client));
            }
        }
    }
}

