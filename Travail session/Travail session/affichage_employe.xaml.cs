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
    public sealed partial class affichage_employe : Page
    {
        public affichage_employe()
        {
            this.InitializeComponent();
            lvEmploye.ItemsSource = Singleton.getInstance().getListeEmploye();
            System.Diagnostics.Debug.WriteLine(Singleton.getInstance().getListeEmploye()[0].Email.ToString());
        }

        private async void gvView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvEmploye.SelectedItem != null)
            {
                modEmploye dialog = new modEmploye();
                dialog.XamlRoot = grille.XamlRoot;
                dialog.Title = "Modification Employe";
                dialog.PrimaryButtonText = "Modifier";
                //dialog.SecondaryButtonText = "Non";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                //dialog.Content = "mon contenu";

                dialog.SetEmploye(Singleton.getInstance().getEmploye(lvEmploye.SelectedIndex));
                ContentDialogResult result = await dialog.ShowAsync();
                lvEmploye.ItemsSource = Singleton.getInstance().getListeEmploye();
            }
        }
    }
}
