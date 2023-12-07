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
using System.Security.Cryptography;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(affichage_projet));
            Singleton.getInstance().Fenetre = this;
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

            var item = args.InvokedItemContainer.Name as string;

           switch (item)
            {
                case "iAffClient":
                    mainFrame.Navigate(typeof(affichage_client));
                    break;
                case "iAffEmploye":
                    mainFrame.Navigate(typeof(affichage_employe));
                    break;
                case "iAjouProjet":
                    mainFrame.Navigate(typeof(affichage_projet));
                    break;
                case "iAjoutClient":
                    if(Singleton.getInstance().GetSessionVariable() == true) mainFrame.Navigate(typeof(ajoutClient));
                    break;
                case "iAjoutEmploye":
                    if (Singleton.getInstance().GetSessionVariable() == true) mainFrame.Navigate(typeof(ajouteEmploye));
                    break;
                case "iAjoutProjet":
                    if (Singleton.getInstance().GetSessionVariable() == true) mainFrame.Navigate(typeof(ajoutProjet));
                    break;
                case "iConnexion":
                    conn();
                    break;
                case "iDeconnexion":
                    Singleton.getInstance().deconnextion();
                    break;
                default:
                    break;
            }
        }

        public async void conn()
        {
            if (Singleton.getInstance().GetSessionVariable() == false)
            {
                connexion dialog = new connexion();
                dialog.XamlRoot = grille.XamlRoot;
                dialog.Title = "Connexion";
                dialog.PrimaryButtonText = "Connexion";
                //dialog.SecondaryButtonText = "Non";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                //dialog.Content = "mon contenu";
                ContentDialogResult result = await dialog.ShowAsync();
            }
            else
            {
                connexion dialog = new connexion();
                dialog.XamlRoot = grille.XamlRoot;
                dialog.Title = "Déja connecté";
                //dialog.PrimaryButtonText = "Connexion";
                dialog.CloseButtonText = "Ok";
                dialog.DefaultButton = ContentDialogButton.Close;
                ContentDialogResult result = await dialog.ShowAsync();
            }
        }


    }
}
