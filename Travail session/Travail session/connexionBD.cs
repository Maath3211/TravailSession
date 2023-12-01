using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_session
{
    class connexionBD
    {
        public static string chaineConnexion = "Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq6;Uid=2234434;Pwd=2234434";
        public string getChaineConnexion()
        {
            return chaineConnexion;
        }
    }
}
