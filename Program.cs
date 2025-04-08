using System;
using System.Linq;
class Program
{
   
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj liczby oddzielone spacjami:");
        string input = Console.ReadLine();
        int[] liczby;
        try
        {
            liczby = input.Split(' ').Select(int.Parse).ToArray();
        }
        catch
        {
            Console.WriteLine("Błąd: Podano niepoprawne dane.");
            return;
        }
        int indeks = ZnajdzIndeksRownowagi(liczby);
        if (indeks != -1)
        {
            Console.WriteLine($"Znaleziono indeks równowagi: {indeks}");
        }
        else
        {
            Console.WriteLine("Nie znaleziono indeksu równowagi.");
        }
    }
    ///***************************************
    /// nazwa funkcji: ZnajdzIndeksRownowagi
    /// typ zwracany: int – zwraca indeks lub -1
    /// informacje: Funkcja szuka indeksu, przy którym suma elementów po lewej stronie jest równa sumie po prawej stronie
    /// autor: Mateusz Chwiałkowski 4D
    ///***************************************
    static int ZnajdzIndeksRownowagi(int[] liczby)
    {
        int sumaCalkowita = liczby.Sum();
        int sumaLewa = 0;
        for (int i = 0; i < liczby.Length; i++)
        {
            int sumaPrawa = sumaCalkowita - sumaLewa - liczby[i];
            if (sumaLewa == sumaPrawa)
            {
                return i;
            }
            sumaLewa += liczby[i];
        }
        return -1;
    }
}