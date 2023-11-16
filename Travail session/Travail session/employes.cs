using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_session
{
    internal class employes
    {
        string matricule;
        string nom;
        string prenom;
        string dateNaissance;
        string naissance;
        string adresse;
        string dateEmbauche;
        double tauxHoraire;
        string photo;
        string statut;

        public employes(string matricule, string nom, string prenom, string dateNaissance, string naissance, string adresse, string dateEmbauche, double tauxHoraire, string photo, string statut)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.naissance = naissance;
            this.adresse = adresse;
            this.dateEmbauche = dateEmbauche;
            this.tauxHoraire = tauxHoraire;
            this.photo = photo;
            this.statut = statut;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Naissance { get => naissance; set => naissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Statut { get => statut; set => statut = value; }
    }
}
