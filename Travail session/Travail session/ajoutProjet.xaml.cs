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

            projets p = new projets(null,tbxTitre.Text,tbxDate.Text,tbxDescription.Text,Convert.ToDouble(tbxBudget.Text),Convert.ToInt32(tbxNbrEmploye.Text),
                Convert.ToDouble(tbxTotalSalaire),Convert.ToInt32(tbxIdClient.Text),tbxStatut.Text);
          Singleton.getInstance().ajouterProjet(p);
            Frame.Navigate(typeof(affichage_projet));
        }
    }
}
