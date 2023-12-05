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
            con = new MySqlConnection(connexionBD.chaineConnexion);
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

        private static Dictionary<string, object> sessionVariables = new Dictionary<string, object>();

        public static void SetSessionVariable(string key, object value)
        {
            sessionVariables[key] = value;
        }

        public static object GetSessionVariable(string key)
        {
            return sessionVariables.ContainsKey(key) ? sessionVariables[key] : null;
        }

        public void creerAdmin(string nom, string pass)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_creerAdmin");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("ID", "NULL");
                commande.Parameters.AddWithValue("username", nom);
                commande.Parameters.AddWithValue("password", pass);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
                    listeEmployes.Add(new employes((string)r["matricule"], (string)r["nom"], (string)r["prenom"], Convert.ToString(r["naissance"]).Substring(0, 10), (string)r["email"],
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
                    listeProjets.Add(new projets((string)r["numProjet"], (string)r["titre"], Convert.ToString(r["debut"]).Substring(0, 10), (string)r["description"],
                        Convert.ToDouble(r["budget"]), Convert.ToInt32(r["nbEmploye"]), Convert.ToDouble(r["totalSalaire"]), Convert.ToInt32(r["client"]), (string)r["statut"]));
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
            return listeProjets;
        }

        public void ajouterClient(clients c)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajoutClient");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("Nnom", c.Nom);
                commande.Parameters.AddWithValue("Nadresse", c.Adresse);
                commande.Parameters.AddWithValue("Nemail", c.Email);
                commande.Parameters.AddWithValue("Ntelephone", c.Telephone);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
        }

        public void ajouterEmploye(employes e)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("ajoutEmploye");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("Nnom", e.Nom);
                commande.Parameters.AddWithValue("Nprenom", e.Prenom);
                commande.Parameters.AddWithValue("Nnaissance", e.Naissance);
                commande.Parameters.AddWithValue("Nemail", e.Email);
                commande.Parameters.AddWithValue("Nadresse", e.Adresse);
                commande.Parameters.AddWithValue("Nembauche", e.DateEmbauche);
                commande.Parameters.AddWithValue("Ntaux_horaire", e.TauxHoraire);
                commande.Parameters.AddWithValue("Nphoto", e.Photo);
                commande.Parameters.AddWithValue("Nstatut", e.Statut);


                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
        }

        public void ajouterProjet(projets p)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajoutProjet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("Ntitre", p.Titre);
                commande.Parameters.AddWithValue("Ndebut", p.DateDebut);
                commande.Parameters.AddWithValue("Ndescription", p.Description);
                commande.Parameters.AddWithValue("Nbudget", p.Budget);
                commande.Parameters.AddWithValue("Nemploye", p.NbrEmploye);
                commande.Parameters.AddWithValue("Ntotal", p.TotalSalaire);
                commande.Parameters.AddWithValue("Nclient", p.IdClient);
                commande.Parameters.AddWithValue("Nstatut", p.Statut);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
        }


        public void modClient(clients c)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_modClient");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("Nid", c.Id);
                commande.Parameters.AddWithValue("Nnom", c.Nom);
                commande.Parameters.AddWithValue("Nadresse", c.Adresse);
                commande.Parameters.AddWithValue("Nemail", c.Email);
                commande.Parameters.AddWithValue("Ntelephone", c.Telephone);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
        }
        public clients getClient(int position)
        {
            return listeClients[position];
        }


        public void modEmploye(employes e)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_modEmploye");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("Nmat", e.Matricule);
                commande.Parameters.AddWithValue("Nnom", e.Nom);
                commande.Parameters.AddWithValue("Nprenom", e.Prenom);
                commande.Parameters.AddWithValue("Nnaissance", e.Naissance);
                commande.Parameters.AddWithValue("Nemail", e.Email);
                commande.Parameters.AddWithValue("Nadresse", e.Adresse);
                commande.Parameters.AddWithValue("Nembauche", e.DateEmbauche);
                commande.Parameters.AddWithValue("Nphoto", e.Photo);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();
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
        }


        public employes getEmploye(int position)
        {
            return listeEmployes[position];
        }
        public projets getProjet(int position)
        {
            return listeProjets[position];
        }

    }
}
