using Gestion_de_fournisseurs;
using Models;
{
    
    Fonction func;
    Gestionnaire gestion;
    gestion = new Gestionnaire();
    gestion.Initialize();
    bool fin = false;
    do
    {
        func = new Fonction();

        Console.WriteLine("|------------|");
        Console.WriteLine("|GESTIONNAIRE|");
        Console.WriteLine("|------------|");
        Console.WriteLine("");
        Console.WriteLine("Menu");
        Console.WriteLine("");
        Console.WriteLine("--------------------");
        Console.WriteLine("| (1) Ajouter      |");
        Console.WriteLine("| (2) Lister       |");
        Console.WriteLine("| (3) Rechercher   |");
        Console.WriteLine("| (4) Modifier     |");
        Console.WriteLine("| (5) Supprimer    |");
        Console.WriteLine("| (0) Quitter      |");
        Console.WriteLine("--------------------");

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      
        switch (keyInfo.Key)
        {
            case ConsoleKey.D0:
            case ConsoleKey.NumPad0:
                fin = true;
                Console.WriteLine("Au revoir");
                break;
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                func.Ajouter(gestion);
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:

                func.Lister(gestion);
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:

                func.Rechercher(gestion);
                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:

                func.Modifier(gestion);
                break;
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:

                func.Supprimer(gestion);
                break;
        }
    } while (!fin);
}