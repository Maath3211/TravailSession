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
using Microsoft.WindowsAppSDK.Runtime.Packages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ajouteEmploye : Page
    {
        public ajouteEmploye()
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
            if (string.IsNullOrEmpty(tbxPrenom.Text))
            {
                erreur = true;
                tbxPrenom.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxEmail.Text))
            {
                erreur = true;
                tbxEmail.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxDateN.Text))
            {
                erreur = true;
                tbxDateN.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxAdresse.Text))
            {
                erreur = true;
                tbxAdresse.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxDateE.Text))
            {
                erreur = true;
                tbxDateE.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxTaux.Text))
            {
                erreur = true;
                tbxTaux.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxPhoto.Text))
            {
                erreur = true;
                tbxPhoto.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxStaut.Text))
            {
                erreur = true;
                tbxStaut.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (!erreur) { 
                employes emp = new employes(null, tbxNom.Text, tbxPrenom.Text, tbxEmail.Text, tbxDateN.Text, tbxAdresse.Text, tbxDateE.Text, Convert.ToDouble(tbxTaux.Text),
               tbxPhoto.Text,tbxStaut.Text );
                Singleton.getInstance().ajouterEmploye(emp);
                Frame.Navigate(typeof(affichage_employe));
            }

            
        }

        
    }
}
