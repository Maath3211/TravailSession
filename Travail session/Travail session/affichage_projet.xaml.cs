using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySqlX.XDevAPI;
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
    public sealed partial class affichage_projet : Page
    {
        public affichage_projet()
        {
            this.InitializeComponent();
            lvProjets.ItemsSource = Singleton.getInstance().getListeProjet();
        }

        private  void lvProjets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProjets.SelectedItem != null)
            {

                if (lvProjets.SelectedItem != null)
                {
                    int position = lvProjets.SelectedIndex;
                    this.Frame.Navigate(typeof(PageZoomProjet), position);
                }

            }
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btEcrireCsv_Click(object sender, RoutedEventArgs e)
        {

            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(Singleton.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "ListeProjet";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            List<projets> liste = new List<projets>();
            liste.AddRange(Singleton.getInstance().getListeProjet());


            // La fonction ToString de la classe Client retourne: nom + ";" + prenom

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.ToStringCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);


        }

        private void lvProjets_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
