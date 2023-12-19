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
        public assignationEmp()
        {
            this.InitializeComponent();
            ajoutCB();
        }

        public void ajoutCB()
        {
            Debug.WriteLine(Singleton.getInstance().getDispo()[1].Nom);

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


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            

            


        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
