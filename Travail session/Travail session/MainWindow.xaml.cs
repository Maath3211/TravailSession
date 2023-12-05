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
            Singleton.SetSessionVariable("NomUtilisateur", "");
            Singleton.SetSessionVariable("Password", "");
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
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
                    mainFrame.Navigate(typeof(ajoutClient));
                    break;
                case "iAjoutEmploye":
                    mainFrame.Navigate(typeof(ajouteEmploye));
                    break;
                case "iAjoutProjet":
                    mainFrame.Navigate(typeof(ajoutProjet));
                    break;
                default:
                    break;
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(tbxTest2.Text));

            StringBuilder sb = new StringBuilder();
            foreach (Byte b in bytes)
                sb.Append(b.ToString("x2"));

            Singleton.SetSessionVariable("NomUtilisateur", tbxTest.Text);
            Singleton.SetSessionVariable("Password", Convert.ToString(sb));
            Singleton.getInstance().creerAdmin(tbxTest.Text, Convert.ToString(sb));
        }

        private void btnAjout2_Click(object sender, RoutedEventArgs e)
        {

            if (tbxTest.Text == (string)Singleton.GetSessionVariable("NomUtilisateur") && tbxTest2.Text ==  (string)Singleton.GetSessionVariable("Password"))
            {
                Debug.WriteLine("Connect�");
            }

            Debug.WriteLine(Singleton.GetSessionVariable("NomUtilisateur"));
            Debug.WriteLine(Singleton.GetSessionVariable("Password"));
        }
    }
}
