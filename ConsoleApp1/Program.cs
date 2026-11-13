using ConsoleApp1;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ===================== 1. CRÉATION DES DONNÉES =====================
var admin = new Administrateur { Id = 1, Nom = "Ben Ali", Prenom = "Sami", Email = "sami@uni.tn" };

var ens1 = new Enseignant { Id = 2, Nom = "Trabelsi", Prenom = "Leila", Email = "leila@uni.tn", Specialite = "Informatique" };
var ens2 = new Enseignant { Id = 3, Nom = "Mansour", Prenom = "Karim", Email = "karim@uni.tn", Specialite = "Mathématiques" };

var e1 = new Etudiant { Id = 4, Nom = "Gharbi", Prenom = "Ahmed", Email = "ahmed@uni.tn", Matricule = "E001" };
var e2 = new Etudiant { Id = 5, Nom = "Mejri", Prenom = "Amira", Email = "amira@uni.tn", Matricule = "E002" };
var e3 = new Etudiant { Id = 6, Nom = "Haddad", Prenom = "Yassine", Email = "yassine@uni.tn", Matricule = "E003" };

var poo = new Matiere { Nom = "POO", Coefficient = 3, Enseignant = ens1 };
var bd = new Matiere { Nom = "Base de données", Coefficient = 2, Enseignant = ens1 };
var maths = new Matiere { Nom = "Mathématiques", Coefficient = 2, Enseignant = ens2 };
ens1.Matieres.Add(poo);
ens1.Matieres.Add(bd);
ens2.Matieres.Add(maths);

var li1 = new Classe { Nom = "LI1" };
var li2 = new Classe { Nom = "LI2" };

var salleA = new Salle { Numero = "A01", Capacite = 40 };
var salleB = new Salle { Numero = "B12", Capacite = 25 };

// Inscriptions (par l'administrateur)
admin.InscrireEtudiant(e1, li1, "2025/2026");
admin.InscrireEtudiant(e2, li1, "2025/2026");
admin.InscrireEtudiant(e3, li2, "2025/2026");

// Séances (planifiées par l'administrateur)
var seances = new[]
{
    (c: li1, s: new Seance { Jour = "Lundi",    HeureDebut = "08:30", HeureFin = "10:00", Matiere = poo,   Salle = salleA }),
    (c: li1, s: new Seance { Jour = "Mardi",    HeureDebut = "10:15", HeureFin = "11:45", Matiere = maths, Salle = salleB }),
    (c: li1, s: new Seance { Jour = "Jeudi",    HeureDebut = "14:00", HeureFin = "15:30", Matiere = bd,    Salle = salleA }),
    (c: li2, s: new Seance { Jour = "Mercredi", HeureDebut = "08:30", HeureFin = "10:00", Matiere = poo,   Salle = salleB }),
};
foreach (var (c, s) in seances)
{
    admin.PlanifierSeance(c, s);
    s.Matiere!.Seances.Add(s);
    s.Salle!.Seances.Add(s);
}

// Notes (saisies par les enseignants)
ens1.SaisirNote(e1, poo, 16);
ens1.SaisirNote(e1, bd, 14);
ens2.SaisirNote(e1, maths, 12);
ens1.SaisirNote(e2, poo, 18);
ens1.SaisirNote(e2, bd, 15);
ens2.SaisirNote(e2, maths, 17);
ens1.SaisirNote(e3, poo, 9);
ens1.SaisirNote(e3, bd, 11);
ens2.SaisirNote(e3, maths, 8);

// ===================== 2. AFFICHAGE =====================

// --- 2.1 Toutes les personnes (polymorphisme : GetRole) ---
Titre("PERSONNES");
var personnes = new List<Personne> { admin, ens1, ens2, e1, e2, e3 };
Console.WriteLine($"{"Id",-4}{"Nom complet",-22}{"Rôle",-16}{"Email"}");
Console.WriteLine(new string('-', 62));
foreach (var p in personnes)
    Console.WriteLine($"{p.Id,-4}{p.GetNomComplet(),-22}{p.GetRole(),-16}{p.Email}");

// --- 2.2 Enseignants et leurs matières ---
Titre("ENSEIGNANTS ET MATIÈRES");
foreach (var ens in new[] { ens1, ens2 })
{
    Console.WriteLine($"{ens.GetNomComplet()} ({ens.Specialite})");
    foreach (var m in ens.Matieres)
        Console.WriteLine($"   - {m.Nom} (coefficient {m.Coefficient})");
}

// --- 2.3 Classes et étudiants inscrits ---
Titre("CLASSES ET ÉTUDIANTS INSCRITS");
foreach (var c in new[] { li1, li2 })
{
    Console.WriteLine($"Classe {c.Nom} : {c.Inscriptions.Count} étudiant(s)");
    foreach (var i in c.Inscriptions)
        Console.WriteLine($"   - {i.Etudiant!.Matricule}  {i.Etudiant.GetNomComplet(),-18} ({i.AnneeUniversitaire})");
}

// --- 2.4 Emploi du temps (méthode de la classe Classe) ---
Titre("EMPLOIS DU TEMPS");
li1.AfficherEmploiDuTemps();
Console.WriteLine();
li2.AfficherEmploiDuTemps();

// --- 2.5 Occupation des salles ---
Titre("OCCUPATION DES SALLES");
foreach (var salle in new[] { salleA, salleB })
{
    Console.WriteLine($"Salle {salle.Numero} (capacité {salle.Capacite}) : {salle.Seances.Count} séance(s)");
    foreach (var s in salle.Seances)
        Console.WriteLine($"   - {s.Jour} {s.HeureDebut}-{s.HeureFin} : {s.Matiere?.Nom} ({s.Classe?.Nom})");
}

// --- 2.6 Bulletins de notes ---
Titre("BULLETINS DE NOTES");
foreach (var e in new[] { e1, e2, e3 })
{
    Console.WriteLine($"{e.GetNomComplet()} ({e.Matricule})");
    foreach (var n in e.Notes)
        Console.WriteLine($"   {n.Matiere!.Nom,-18} coef {n.Matiere.Coefficient}   note : {n.Valeur,5:0.00}");
    Console.WriteLine($"   >>> Moyenne : {e.CalculerMoyenne():0.00}/20\n");
}

// --- 2.7 Classement ---
Titre("CLASSEMENT");
int rang = 1;
foreach (var e in new[] { e1, e2, e3 }.OrderByDescending(x => x.CalculerMoyenne()))
    Console.WriteLine($"{rang++}. {e.GetNomComplet(),-18} {e.CalculerMoyenne():0.00}/20");

Console.WriteLine("\nAppuyez sur une touche pour quitter...");
Console.ReadKey();

// ===================== OUTIL =====================
static void Titre(string texte)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 62));
    Console.WriteLine($"  {texte}");
    Console.WriteLine(new string('=', 62));
}