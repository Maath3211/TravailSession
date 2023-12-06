using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Travail_session
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class affichage_client : Page
    {
        public affichage_client()
        {
            this.InitializeComponent();
            lvClients.ItemsSource = Singleton.getInstance().getListeClients();
            Singleton.getInstance().connexion();
        }

        
        public async void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Singleton.GetSessionVariable() == true)
            {
                if (lvClients.SelectedItem != null)
                {
                    ModifierClient dialog = new ModifierClient();
                    dialog.XamlRoot = grille.XamlRoot;
                    dialog.Title = "Modification client";
                    dialog.PrimaryButtonText = "Modifier";
                    //dialog.SecondaryButtonText = "Non";
                    dialog.CloseButtonText = "Annuler";
                    dialog.DefaultButton = ContentDialogButton.Primary;
                    //dialog.Content = "mon contenu";

                    dialog.SetClient(Singleton.getInstance().getClient(lvClients.SelectedIndex));
                    ContentDialogResult result = await dialog.ShowAsync();
                    lvClients.ItemsSource = Singleton.getInstance().getListeClients();
                }
            }
        }
    }
}
