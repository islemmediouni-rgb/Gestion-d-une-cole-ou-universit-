using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    public abstract class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Email { get; set; } = "";

        public abstract string GetRole();

        public string GetNomComplet() => $"{Prenom} {Nom}";
    }
}