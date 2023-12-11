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
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    public sealed partial class modEmploye : ContentDialog
    {
        employes e = null;
        public modEmploye()
        {
            this.InitializeComponent();
            
            
        }

        public void SetEmploye(employes employe)
        {
            e = employe;
            tbxMat.Text = Convert.ToString(e.Matricule);
            tbxNom.Text = Convert.ToString(e.Nom);
            tbxPrenom.Text = Convert.ToString(e.Prenom);
            tbxNaissance.Text = Convert.ToString(e.Naissance);
            tbxEmail.Text = Convert.ToString(e.Email);
            tbxAdresse.Text = Convert.ToString(e.Adresse);
            tbxTaux.Text = Convert.ToString(e.TauxHoraire);
            tbxEmbauche.Text = Convert.ToString(e.DateEmbauche);
            tbxPhoto.Text = Convert.ToString(e.Photo);

            DateTime dateEmbauche = Convert.ToDateTime(e.DateEmbauche);
            TimeSpan difference = DateTime.Today - dateEmbauche;
            if (difference.TotalDays >= 1095)
            {
                cbStatut.Items.Add("Permanent");
            }

            cbStatut.SelectedValue = Convert.ToString(e.Statut);

            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
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
            if (string.IsNullOrEmpty(tbxAdresse.Text))
            {
                erreur = true;
                tbxAdresse.BorderBrush = new SolidColorBrush(Colors.Red);
            }
         
            if (string.IsNullOrEmpty(tbxPhoto.Text))
            {
                erreur = true;
                tbxPhoto.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            if (string.IsNullOrEmpty(tbxTaux.Text))
            {
                erreur = true;
                tbxTaux.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (!erreur) Singleton.getInstance().modEmploye(new employes(tbxMat.Text, tbxNom.Text, tbxPrenom.Text, tbxNaissance.Text, tbxEmail.Text, tbxAdresse.Text,tbxEmbauche.Text,Convert.ToDouble(tbxTaux.Text),tbxPhoto.Text, (string)cbStatut.SelectedValue));
            else args.Cancel = true;


        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
