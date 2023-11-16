using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_session
{
    internal class projets
    {
        string numeroProjet;
        string titre;
        string dateDebut;
        string description;
        double budget;
        int nbrEmploye;
        double totalSalaire;
        int idClient;
        string statut;

        public projets(string numeroProjet, string titre, string dateDebut, string description, double budget, int nbrEmploye, double totalSalaire, int idClient, string statut)
        {
            this.numeroProjet = numeroProjet;
            this.titre = titre;
            this.dateDebut = dateDebut;
            this.description = description;
            this.budget = budget;
            this.nbrEmploye = nbrEmploye;
            this.totalSalaire = totalSalaire;
            this.idClient = idClient;
            this.statut = statut;
        }

        public string NumeroProjet { get => numeroProjet; set => numeroProjet = value; }
        public string Titre { get => titre; set => titre = value; }
        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string Description { get => description; set => description = value; }
        public double Budget { get => budget; set => budget = value; }
        public int NbrEmploye { get => nbrEmploye; set => nbrEmploye = value; }
        public double TotalSalaire { get => totalSalaire; set => totalSalaire = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public string Statut { get => statut; set => statut = value; }
    }
}
