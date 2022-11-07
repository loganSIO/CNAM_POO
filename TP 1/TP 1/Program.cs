using System;
using System.Globalization;
using System.Threading;

class Program
{
   public static void Main(string[] args)
    {
        string? surname, prenom, demandeTaille, demandePoids,
            demandeAge, userInput;
        float taille, poids;
        int age;

        do
        {
            do
            {
                Console.WriteLine("Votre nom :");
                surname = Console.ReadLine();
            } while (surname.Any(char.IsDigit));
            do
            {
                Console.Write("Votre prénom :");
                prenom = Console.ReadLine();
            } while (prenom.Any(char.IsDigit));

            do
            {
                Console.WriteLine("Votre taille (en m) :");
                demandeTaille = Console.ReadLine();
            } while (!float.TryParse(demandeTaille, NumberStyles.Number,  CultureInfo.InvariantCulture, out taille) || taille < 0);
            do
            {
                Console.WriteLine("Votre poids svp :");
                demandePoids = Console.ReadLine();
            } while (!float.TryParse(demandePoids, NumberStyles.Number, CultureInfo.InvariantCulture, out poids) || poids < 0);
            do
            {
                Console.WriteLine("Votre âge :");
                demandeAge = Console.ReadLine();
            } while (!int.TryParse(demandeAge, out age) || age < 0);

            if (age < 18)
            {
                Console.WriteLine($"Frero, tu as {age} ans, respecte toi !");
            }
            else
            {
                Console.WriteLine(PrenomNom(prenom, surname));
                Console.WriteLine($"Tu mesures : {taille} tu pèses {poids} " +
                    $"et tu as {age} ans !");
                NombreCheveux();
                float calculImc = Imc(taille, poids);
                CommentaireIMC(calculImc);
            }

            userInput = Possibilities();

        } while (userInput == "2");
    }

    public static string Possibilities()
    {
        Console.WriteLine("Voulez-vous: \n1. Quitter \n2. Recommencer \n3. Compter jusqu'à 10 \n4. Appeler Tata Jacqueline");
        string? possibility = Console.ReadLine();

        switch (possibility)
        {
            case "1":
                {
                    Console.WriteLine("Au revoir !");
                    Thread.Sleep(3000);
                }
                break;
            case "2":
                {
                    Console.WriteLine("Et c'est raparti pour un tour !");
                }
                break;
            case "3":
                {
                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                }
                break;
            case "4":
                {
                    Console.WriteLine("aLo , j'EnTeNd RiEn !!!! alLo?");
                }
                break;
            default:
                {
                    possibility = "1";
                }
                break;
        }
        return possibility;
    }

    public static string PrenomNom(string prenom, string nom)
    {
        return prenom.ToLower() + nom.ToUpper();
    }

    public static float Imc(float taille, float poids)
    {
        return poids / (taille * taille);
    }

    public static void CommentaireIMC(float imc)
    {
        const string ANOREXIE = "Attention à l'anorexie !";
        const string MAIGRICHON = "Vous êtes un peu maigrichon !";
        const string NORMALE = "Vous êtes de corpulence normale !";
        const string SURPOIDS = "Vous êtes en surpoids !";
        const string MODEREE = "Obésité modérée !";
        const string SEVERE = "Obésité sévère !";
        const string MORBIDE = "Obésité morbide !";
        
        if (imc < 16.5)
        {
            Console.WriteLine(ANOREXIE);
        }
        else if (imc >= 16.5 && imc < 18.5)
        {
            Console.WriteLine(MAIGRICHON);
        }
        else if (imc >= 18.5 && imc < 25)
        {
            Console.WriteLine(NORMALE);
        }
        else if (imc >= 25 && imc < 30)
        {
            Console.WriteLine(SURPOIDS);
        }
        else if (imc >= 30 && imc < 35)
        {
            Console.WriteLine(MODEREE);
        }
        else if (imc >= 35 && imc < 40)
        {
            Console.WriteLine(SEVERE);
        }
        else
        {
            Console.WriteLine(MORBIDE);
        }
    }

    public static void NombreCheveux()
    {
        bool saisieIncorrect = true;

        while (saisieIncorrect)
        {
            Console.WriteLine("Combien de cheveux penses-tu avoir :");
            string? nbCheveux = Console.ReadLine();
            int convertCheveux = 0;
            bool valueNb = int.TryParse(nbCheveux, out convertCheveux);

            if (valueNb && (convertCheveux > 100000 && convertCheveux < 150000))
            {
                Console.WriteLine($"Bravo, tu as {convertCheveux} cheveux !");
                saisieIncorrect = false;
            }
            else
            {
                Console.WriteLine("Erreur, recommence avec un nombre et entre les bornes 100.000 et 150.000 !");
            }
        }
    }
}