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
    public sealed partial class ajoutProjet : Page
    {
        public ajoutProjet()
        {
            this.InitializeComponent();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            var erreur = false;
            if (string.IsNullOrEmpty(tbxTitre.Text))
            {
                erreur = true;
                tbxTitre.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxDate.Text))
            {
                erreur = true;
                tbxDate.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxDescription.Text))
            {
                erreur = true;
                tbxDescription.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxBudget.Text))
            {
                erreur = true;
                tbxBudget.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (!double.TryParse(tbxBudget.Text, out double result))
                {
                    erreur = true;
                    tbxBudget.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }

            if (string.IsNullOrEmpty(tbxNbrEmploye.Text))
            {
                erreur = true;
                tbxNbrEmploye.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (!double.TryParse(tbxNbrEmploye.Text, out double result))
                {
                    erreur = true;
                    tbxNbrEmploye.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            if (string.IsNullOrEmpty(tbxTotalSalaire.Text))
            {
                erreur = true;
                tbxTotalSalaire.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (!double.TryParse(tbxTotalSalaire.Text, out double result))
                {
                    erreur = true;
                    tbxTotalSalaire.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            if (string.IsNullOrEmpty(tbxIdClient.Text))
            {
                erreur = true;
                tbxIdClient.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxStatut.Text))
            {
                erreur = true;
                tbxStatut.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (!erreur)
            {
                projets p = new projets(null, tbxTitre.Text, tbxDate.Text, tbxDescription.Text, Convert.ToDouble(tbxBudget.Text), Convert.ToInt32(tbxNbrEmploye.Text),
                    Convert.ToDouble(tbxTotalSalaire.Text), Convert.ToInt32(tbxIdClient.Text), tbxStatut.Text);
                Singleton.getInstance().ajouterProjet(p);
                Frame.Navigate(typeof(affichage_projet));
            }
        }
    }
}
