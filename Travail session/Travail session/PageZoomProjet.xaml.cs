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
    public sealed partial class PageZoomProjet : Page
    {
        public PageZoomProjet()
        {
            this.InitializeComponent();
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
                    tblTitre.Text = p.Titre;
                    tblDebut.Text = p.DateDebut;
                    tblDescription.Text = p.Description;
                    tblBudget.Text = Convert.ToString( p.Budget);
                    tblNbr.Text = Convert.ToString(p.NbrEmploye);
                    tblTotal.Text = Convert.ToString(p.TotalSalaire);
                    tblClient.Text = Convert.ToString(p.IdClient);
                    tblStatut.Text = p.Statut;

                }


            }
        }







    }
}
