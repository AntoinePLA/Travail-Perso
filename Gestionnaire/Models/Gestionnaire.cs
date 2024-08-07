namespace Models
{
    public class Gestionnaire
    {
        const int taille = 50;
        public Fournisseur[] Tab;
        public int pose;

        public void Initialize()
        {
            Tab = new Fournisseur[taille];
            for (int i = 0; i < taille; i++)
            {
                Tab[i] = new Fournisseur();
            }
        }

        public Fournisseur AjoutFournisseur()
        {
            Fournisseur Fourn = new Fournisseur();
            string InpString = "";
            int InpInt = 0;

            Console.Write("Nom du Fournisseur : \n > ");
            InpString = Console.ReadLine()!;
            Fourn.Name = InpString;

            Console.Write("Mail : \n > ");
            InpString = Console.ReadLine()!;
            Fourn.Email = InpString;

            Console.Write("ID : \n > ");
            InpString = Console.ReadLine()!;
            InpInt = int.Parse(InpString);
            Fourn.Id = InpInt;

            Console.Write("Tel : \n > ");
            InpString = Console.ReadLine()!;
            InpInt = int.Parse(InpString);
            Fourn.Tel = InpInt;

            do
            {
                Console.WriteLine("Y a t'il une commande en cours ? (oui / non)");
                InpString = Console.ReadLine()!;
            } while (InpString != "oui" && InpString != "non");

            if (InpString == "oui")
            {
                Fourn.Command = true;
            }
            else
            {
                Fourn.Command = false;
            }

            return Fourn;
        }
    }
}
