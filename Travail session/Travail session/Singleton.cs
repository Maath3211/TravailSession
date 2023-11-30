using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_session
{
    internal class Singleton
    {

        ObservableCollection<clients> listeClients;
        ObservableCollection<employes> listeEmployes;
        static Singleton instance = null;
        MySqlConnection con;
        public Singleton()
        {
            listeClients = new ObservableCollection<clients>();
            listeEmployes = new ObservableCollection<employes>();
            listeClients.Add(new clients(100, "Mathys Lessard", "2371 lac-rond", "mathys.l.lessard@gmail.com", "819-222-2222"));
            listeEmployes.Add(new employes(" DO-1978-25", "Doe", "John", "2010-12-01", "test@gmail.com", "22 rue boulevier", "2023-01-01", 20, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.21-draw.com%2Ffr%2Fcharacter-design-tips%2F&psig=AOvVaw0Brub9FbOtJEu-77G3BzRn&ust=1700250537743000&source=images&cd=vfe&opi=89978449&ved=0CA8QjRxqFwoTCMCT-P2kyYIDFQAAAAAdAAAAABAD", "journalier"));
        }


        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();

            return instance;
        }

        public ObservableCollection<clients> getListeClients()
        {
            return listeClients;
        }

    }
}
