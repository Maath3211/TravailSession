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
using System.Diagnostics;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    public sealed partial class modProjet : ContentDialog

    {
        projets p = null;
        public modProjet()
        {
            this.InitializeComponent();
        }


        public void SetProjet(projets projet)
        {
            p = projet;
            tbxTitre.Text = Convert.ToString(p.Titre);
            tbxDebut.Text = Convert.ToString(p.DateDebut);
            tbxDescription.Text = Convert.ToString(p.Description);
            tbxBudget.Text = Convert.ToString(p.Budget);
            cbEmploye.Text = Convert.ToString(p.NbrEmploye);
            tbxTotalSalaire.Text = Convert.ToString(p.TotalSalaire);
     
        }



        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            var erreur = false;
            if (string.IsNullOrEmpty(tbxTitre.Text))
            {
                erreur = true;
                tbxTitre.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxDebut.Text))
            {
                erreur = true;
                tbxDebut.BorderBrush = new SolidColorBrush(Colors.Red);
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
            if (string.IsNullOrEmpty(cbEmploye.Text))
            {
                erreur = true;
                cbEmploye.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (string.IsNullOrEmpty(tbxTotalSalaire.Text))
            {
                erreur = true;
                tbxTotalSalaire.BorderBrush = new SolidColorBrush(Colors.Red);
            }


            if (!erreur) Singleton.getInstance().modProjet(new projets(p.NumeroProjet,tbxTitre.Text,tbxDebut.Text,tbxDescription.Text,Convert.ToDouble(tbxBudget.Text),Convert.ToInt32( cbEmploye.SelectedItem),Convert.ToDouble(tbxTotalSalaire.Text), p.IdClient, p.Statut));
            else args.Cancel = true;

        }
        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
