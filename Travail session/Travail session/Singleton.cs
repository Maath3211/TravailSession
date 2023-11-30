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
        ObservableCollection<projets> listeProjets;
        static Singleton instance = null;
        MySqlConnection con;
        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2023_420325ri_fabeq6;Uid=2234434;Pwd=2234434");
            listeClients = new ObservableCollection<clients>();
            listeEmployes = new ObservableCollection<employes>();
            listeProjets = new ObservableCollection<projets>();
        }


        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();

            return instance;
        }

        public ObservableCollection<clients> getListeClients()
        {
            listeClients.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("p_afficher_client");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                if (con.State == System.Data.ConnectionState.Closed) con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    listeClients.Add(new clients(Convert.ToInt32(r["id"]), (string)r["nom"], (string)r["adresse"], (string)r["email"], (string)r["telephone"]));
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    con.Close();
                }

            }
            return listeClients;
        }

        public ObservableCollection<employes> getListeEmploye()
        {
            listeEmployes.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("p_afficher_employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                if (con.State == System.Data.ConnectionState.Closed) con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    listeEmployes.Add(new employes((string)r["matricule"], (string)r["nom"], (string)r["prenom"], Convert.ToString(r["naissance"]), (string)r["email"],
                        (string)r["adresse"], Convert.ToString(r["embauche"]), Convert.ToDouble(r["taux_horaire"]), (string)r["photo"], (string)r["statut"]));
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    con.Close();
                }

            }
            return listeEmployes;
        }

        public ObservableCollection<projets> getListeProjet()
        {
            listeProjets.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("p_afficher_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                if (con.State == System.Data.ConnectionState.Closed) con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    listeEmployes.Add(new employes((string)r["matricule"], (string)r["nom"], (string)r["prenom"], (string)r["naissance"], (string)r["email"],
                        (string)r["adresse"], (string)r["embauche"], Convert.ToDouble(r["taux_horaire"]), (string)r["photo"], (string)r["statut"]));
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    con.Close();
                }

            }
            return listeClients;
        }
    }
}
