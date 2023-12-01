using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_session
{
    public class clients
    {
        int id;
        string nom, adresse, email, telephone;

        public clients(int id, string nom, string adresse, string email, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.email = email;
            this.telephone = telephone;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        

        //listeClients.Add(new clients(100, "Mathys Lessard", "2371 lac-rond", "mathys.l.lessard@gmail.com","819-222-2222"));






    }
}
