using Classi;

public class Program
{
    private static Famiglia mFamiglia;

    public static void Main()
    {
        try
        {
            mFamiglia = Famiglia.Deserializza();

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Componenti della famiglia in base alla data di nasita (crescente): ");
                PrintComponentiFamiglia(mFamiglia.SorComponentiFamigliaDataNascita());

                int input;
                do
                {
                    Console.Write("Per aggiungere un componente scrivere 1, 2 per uscire: ");
                    input = int.Parse(Console.ReadLine());
                } while (input > 2 || input < 1);

                switch (input)
                {
                    case 1:
                        string nome;
                        Console.Write("Inserire in nome: ");
                        nome = Console.ReadLine();

                        string cognome;
                        Console.Write("Inserire il cognome: ");
                        cognome = Console.ReadLine();

                        string data_nascita;
                        string[] data_split;
                        Console.Write("Inserire la data di nascita (dd/mm/aaaa): ");
                        data_nascita = Console.ReadLine();
                        data_split = data_nascita.Split('/');
                        if (data_split.Length != 3)
                            throw new Exception("Errore: Data di Nascita non corretta");

                        mFamiglia.Componenti.Add(
                            new Persona(nome, cognome, new DateTime(int.Parse(data_split[2]), int.Parse(data_split[1]), int.Parse(data_split[0])))
                            );

                        Famiglia.Serializza(mFamiglia);
                        break;
                    default:
                        loop = false;
                        break;

                }
            }
            
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static void PrintComponentiFamiglia(List<Persona> persone)
    {
        Console.WriteLine("####################################################");
        Console.WriteLine("# Nome             Cognome          Data Nascita   #");
        foreach (Persona persona in persone)
        {
            Console.WriteLine("# " + persona.ToString() + " #");
        }
        Console.WriteLine("####################################################");
    }
}