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
    public sealed partial class assignationEmp : ContentDialog
    {
        string pro = "";
        double hr = 0;
        int nbEmp = 0;
        public assignationEmp()
        {
            this.InitializeComponent();
            ajoutCB();
            
        }

        public void ajoutCB()
        {
            for (int i = 0; i < Singleton.getInstance().getDispo().Count; i++)
            {
                string nom = Singleton.getInstance().getDispo()[i].Nom + ", " + Singleton.getInstance().getDispo()[i].Prenom;
                cbAss1.Items.Add(nom);
                cbAss2.Items.Add(nom);
                cbAss3.Items.Add(nom);
                cbAss4.Items.Add(nom);
                cbAss5.Items.Add(nom);
            }
        }

        public void SetProj(string proj, double hre, int nbEmp)
        {
            pro = proj;
            hr = hre;
            this.nbEmp = nbEmp;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Singleton.getInstance().ajoutPE(Singleton.getInstance().getDispo()[cbAss1.SelectedIndex].Matricule, pro, hr, 0);



            
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
