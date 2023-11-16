using Microsoft.WindowsAppSDK.Runtime.Packages;
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
        static Singleton instance = null;
        public Singleton()
        {
            listeClients = new ObservableCollection<clients>();
            listeClients.Add(new clients(100, "Mathys Lessard", "2371 lac-rond", "mathys.l.lessard@gmail.com", "819-222-2222"));
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
