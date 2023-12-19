using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageZoomProjet : Page
    {
        projets p;
        public PageZoomProjet()
        {
            this.InitializeComponent();
            if (Singleton.getInstance().GetSessionVariable())
            {
                modifier.Visibility = Visibility.Visible;
                btAjoutEmp.Visibility = Visibility.Visible;
            }
           
        }
        int position = -1;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is not null)
            {
                position = (int)e.Parameter;
                if (position >= 0)
                {
                    projets p = Singleton.getInstance().getListeProjet()[position];
                    clients c = Singleton.getInstance().getListeClients()[position];
                    tblTitre.Text = p.Titre;
                    tblDebut.Text = p.DateDebut;
                    tblDescription.Text = p.Description;
                    tblBudget.Text = Convert.ToString(p.Budget);
                    tblNbr.Text = Convert.ToString(p.NbrEmploye);
                    tblTotal.Text = Convert.ToString(p.TotalSalaire);
                    tblClient.Text = Convert.ToString(c.Nom);
                    tblStatut.Text = p.Statut;
                    
                }


            }
        }

        private async void modifier_Click(object sender, RoutedEventArgs e)
        {
            if (Singleton.getInstance().GetSessionVariable())
            {


                modProjet dialog = new modProjet();
                dialog.XamlRoot = grille.XamlRoot;
                dialog.Title = "Modification Employe";
                dialog.PrimaryButtonText = "Modifier";
                //dialog.SecondaryButtonText = "Non";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                //dialog.Content = "mon contenu";

                dialog.SetProjet(Singleton.getInstance().getListeProjet()[position]);
                ContentDialogResult result = await dialog.ShowAsync();
                projets p = Singleton.getInstance().getListeProjet()[position];
                tblTitre.Text = p.Titre;
                tblDebut.Text = p.DateDebut;
                tblDescription.Text = p.Description;
                tblBudget.Text = Convert.ToString(p.Budget);
                tblNbr.Text = Convert.ToString(p.NbrEmploye);
                tblTotal.Text = Convert.ToString(p.TotalSalaire);
                tblClient.Text = Convert.ToString(p.IdClient);
                tblStatut.Text = p.Statut;
            }
        }

        private async void btAjoutEmp_Click(object sender, RoutedEventArgs e)
        {
            assignationEmp dialog = new assignationEmp();
            dialog.XamlRoot = grille.XamlRoot;
            dialog.Title = "Assignation Employe";
            dialog.PrimaryButtonText = "Modifier";
            //dialog.SecondaryButtonText = "Non";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            //dialog.Content = "mon contenu";
            projets p = Singleton.getInstance().getListeProjet()[position];
            dialog.SetProj(p.NumeroProjet, p.Budget, p.NbrEmploye);
            ContentDialogResult result = await dialog.ShowAsync();
        }
    }
}
