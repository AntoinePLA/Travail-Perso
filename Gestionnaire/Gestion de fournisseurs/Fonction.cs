using Models;
using System.Text.RegularExpressions;

namespace Gestion_de_fournisseurs
{
    public struct Fonction
    {
        public void Ajouter(Gestionnaire gestion)
        {
            int Pose = -1;

            Console.Clear();
            Pose = ChercherVide(gestion.Tab);
            if (Pose == -1)
            {
                Console.WriteLine("Le gestionnaire est plain");
            }
            else
            {
                Fournisseur Nouveau;
                Nouveau = gestion.AjoutFournisseur();

                for (int i = 0; i < gestion.Tab.Length; i++)
                {
                    if (Nouveau.Email == gestion.Tab[i].Email)
                    {
                        throw new Exception("L'Email est déjà utilisé");
                    }
                    if (Nouveau.Id == gestion.Tab[i].Id)
                    {
                        throw new Exception("l'ID déjà utilisé");
                    }
                }
                gestion.Tab[Pose] = Nouveau;
            }
        }

        public void Lister(Gestionnaire gestion)
        {
            bool Check = false;
            Console.Clear();
            for (int i = 0; i < gestion.Tab.Length; i++)
            {
                if (gestion.Tab[i].Id != -1 && gestion.Tab[i].Email != "")
                {
                    Console.WriteLine($"Id: {gestion.Tab[i].Id} \t Nom: {gestion.Tab[i].Name}");
                    Check = true;
                }
            }
            if (!Check)
            {
                Console.WriteLine("Il n'y a personne dans le gestionnaire");
            }
        }

        public int ChercherVide(Fournisseur[] tab)
        {
            int Pose = -1;
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i].Id == -1 && tab[i].Email == "")
                {
                    Pose = i;
                }
            }
            return Pose;
        }

        public int MenuRecherche()
        {
            int Choix = -1;
            bool fin = false;
            do
            {
                Console.WriteLine("Vous voulez chercher par : ");
                Console.WriteLine("(1) Nom");
                Console.WriteLine("(2) ID");
                Console.WriteLine("(0) Retour");
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Choix = -1;
                        fin = true;
                        break;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Choix = 1;
                        fin = true;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Choix = 2;
                        fin = true;
                        break;
                }
            } while (!fin);
            return Choix;
        }

        public void Rechercher(Gestionnaire gestion)
        {
            int Choix = -1;
            int Pose = -1;
            string Inp = "";
            string com = "Il n'y a pas de commande en cours";

            Choix = MenuRecherche();
            switch (Choix)
            {
                case 1:
                    Console.Write("Nom: \n > ");
                    Inp = Console.ReadLine()!.ToUpper();
                    break;
                case 2:
                    Console.Write("ID: \n > ");
                    Inp = Console.ReadLine()!;
                    break;
            }
            for (int i = 0; i < gestion.Tab.Length; i++)
            {
                if (Choix == 1 && Inp == gestion.Tab[i].Name || Choix == 2 && int.Parse(Inp) == gestion.Tab[i].Id)
                {
                    Pose = i;
                }                
            }
            Console.Clear();
            if (Pose == -1)
            {
                Console.WriteLine("Ce fournisseur n'existe pas");
            }
            else
            {
                if (gestion.Tab[Pose].Command)
                { com = "Commande en cours"; }
                Console.WriteLine($"Nom: {gestion.Tab[Pose].Name} \nEmail: {gestion.Tab[Pose].Email} \nTel: 0{gestion.Tab[Pose].Tel} \n{com}");
            }
        }

        public bool Confirmation(int Z, Gestionnaire gestion, Fournisseur nouveau, string inp)
        {
            bool Confirmer = false;
            string Inp = "";
            switch (Z)
            {
                case 1:
                    do
                    {
                        Console.Write("(oui/non) >");
                        Inp = Console.ReadLine()!.ToLower();

                    } while (Inp != "oui" && Inp != "non");
                    if (Inp == "oui")
                    {
                        Confirmer = true;
                    }
                    break;
                case 2:
                    if (Regex.IsMatch(inp, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])"))
                    {
                        Confirmer = true;
                    }
                    for (int i = 0; i < gestion.Tab.Length; i++)
                    {
                        if (inp == gestion.Tab[i].Email)
                        {
                            Confirmer = false;
                            throw new Exception("L'Email est déjà utilisé");
                        }
                    }
                    break;
            }
            return Confirmer;
        }

        public void Modifier(Gestionnaire gestion)
        {
            int Choix = -1;
            bool Confirm = false;
            bool fin =false;
            int Pose = -1;
            string Inp = "";
            string com = "";
            Fournisseur Nouveau = new Fournisseur();

            Choix = MenuRecherche();

            switch (Choix)
            {
                case 1:
                    Console.Write("Nom: \n > ");
                    Inp = Console.ReadLine()!.ToUpper();
                    break;
                case 2:
                    Console.Write("ID: \n > ");
                    Inp = Console.ReadLine()!;
                    break;
            }
            for (int i = 0; i < gestion.Tab.Length; i++)
            {
                if (Choix == 1 && Inp == gestion.Tab[i].Name || Choix == 2 && int.Parse(Inp) == gestion.Tab[i].Id)
                {
                    Pose = i;
                }
            }
            Console.Clear();
            if (Pose == -1)
            {
                Console.WriteLine("Ce fournisseur n'existe pas");
            }
            else
            {
                do
                {
                    Nouveau = gestion.Tab[Pose];                    
                    
                    if (Nouveau.Command)
                    {
                        com = "Commande en cours";
                    }
                    else
                    {
                        com = "Il n'y a pas de commande en cours";
                    }
                    Console.Clear();
                    Console.WriteLine("Que veux-tu changer ?");
                    Console.WriteLine($"(1) Nom: {Nouveau.Name} \n(2) Email: {Nouveau.Email} \n(3) Tel: 0{Nouveau.Tel} \n(4) {com} \n(0) Sortir");
                    
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.NumPad0:
                        case ConsoleKey.D0:
                            Console.Clear();
                            Console.WriteLine("Confirmer les changements ?");
                            Console.WriteLine($"Nouveau Nom: {Nouveau.Name} \nNouvel Email: {Nouveau.Email} \nNouveau Tel: 0{Nouveau.Tel} \nNouveel etat {com}");
                            Confirm = Confirmation(1,gestion,Nouveau,"");
                            if (Confirm)
                            {
                                gestion.Tab[Pose] = Nouveau;
                            }
                            fin = true;
                            break;
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            Console.Write("Nouveau Nom: \n > ");
                            Inp = Console.ReadLine()!.ToUpper();
                            Console.WriteLine($"Nouveau Nom:\t{Inp}");
                            Confirm = Confirmation(1, gestion, Nouveau, "");
                            if (Confirm)
                            {
                                Nouveau.Name = Inp;
                            }
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.Write("Nouveau Email: \n > ");
                            Inp = Console.ReadLine()!;
                            Console.WriteLine($"Nouvel Email:\t{Inp}");
                            Confirm = Confirmation(1, gestion, Nouveau, "");
                            if (Confirm)
                            {
                                Confirm = Confirmation(2, gestion, Nouveau, Inp);
                            }
                            if (Confirm)
                            {
                                Nouveau.Email = Inp;
                            }
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Console.Write("Nouveau Tel: \n > ");
                            Inp = Console.ReadLine()!.ToUpper();
                            Console.WriteLine($"Nouveau Tel:\t{Inp}");
                            Confirm = Confirmation(1, gestion, Nouveau, "");
                            if (Confirm)
                            {
                                Nouveau.Tel = int.Parse(Inp);
                            }
                            break;
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            if (Nouveau.Command)
                            {
                                Console.WriteLine("Il y a actuellement une commande en cours, voulez-vous l'arreter ?");
                                Confirm = Confirmation(1, gestion, Nouveau, "");
                                if (!Confirm)
                                {
                                    Nouveau.Command = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Il n'y a pas de commande en cours, voulez-vous la lancer ?");
                                Confirm = Confirmation(1, gestion, Nouveau, "");
                                if (Confirm)
                                {
                                    Nouveau.Command = true;
                                }
                            }
                            break;
                    }
                } while (!fin);
            }
        }

        public void Supprimer(Gestionnaire gestion)
        {
            int Choix = -1;
            bool Confirm = false;
            int Pose = -1;
            string Inp = "";

            Choix = MenuRecherche();

            switch (Choix)
            {
                case 1:
                    Console.Write("Nom: \n > ");
                    Inp = Console.ReadLine()!.ToUpper();
                    break;
                case 2:
                    Console.Write("ID: \n > ");
                    Inp = Console.ReadLine()!;
                    break;
            }
            Console.Clear();
            for (int i = 0; i < gestion.Tab.Length; i++)
            {
                if (Choix == 1 && Inp == gestion.Tab[i].Name || Choix == 2 && int.Parse(Inp) == gestion.Tab[i].Id)
                {
                    Pose = i;
                }
            }
            if (Pose == - 1)
            {
                Console.WriteLine("Ce fournisseur n'existe pas");
            }
            else if (gestion.Tab[Pose].Command)
            {
                Console.WriteLine($"{gestion.Tab[Pose].Name} :");
                Console.WriteLine("Imposible à supprimer, commande en cours");
            }
            else
            {
                Console.WriteLine($"Nom: {gestion.Tab[Pose].Name} \nEmail: {gestion.Tab[Pose].Email} \nTel: 0{gestion.Tab[Pose].Tel}");
                Console.WriteLine("CONFIRMER LA SUPPRESION ?");
                do
                {
                    Console.WriteLine("(oui / non) > ");
                    Inp = Console.ReadLine()!.ToLower();
                } while (Inp != "oui" && Inp != "non");
                if (Inp == "oui")
                {
                    Fournisseur Supp = new Fournisseur();
                    gestion.Tab[Pose] = Supp;
                }
            }
        }
    }
}
