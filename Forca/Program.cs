using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

List<string> Palavras = new List<string>
{
    "BRASIL",
    "NORUEGA",
    "AUSTRIA",
    "FRANÇA",
    "ARGENTINA",
    "URUGUAY",
    "CHILE",
    "MOÇAMBIQUE",
    "CHINA",
    "PERU"
};

int Vidas = 6;

Random random = new Random();

StringBuilder letras = new StringBuilder();

string Palavra = Palavras[random.Next(0, Palavras.Count)];

SortedSet<string> LetrasCorretas = new SortedSet<string>();

SortedSet<string> LetrasErradas = new SortedSet<string>();

for (int i = 0; i < Palavra.Length; i++)
{
    letras.Append("_");
}

Console.WriteLine(letras.ToString().Trim());
Console.WriteLine("\nDigite uma letra:");

while (Vidas > 0 && letras.ToString().Contains("_"))
{
    string entrada = Console.ReadLine().ToUpper();

    while (entrada.Length != 1 || !Regex.IsMatch(entrada, @"^[a-zA-Z]+$"))
    {
        Console.WriteLine("Entrada inválida. Digite uma única letra:");
        entrada = Console.ReadLine().ToUpper();
    }

    if (LetrasCorretas.Contains(entrada) || LetrasErradas.Contains(entrada))
    {
        Console.WriteLine("Letra já usada");
    }
    else
    {
        if (Palavra.Contains(entrada))
        {
            for (int i = 0; i < Palavra.Length; i++)
            {
                if (entrada == Palavra[i].ToString())
                {
                    letras[i] = entrada[0];
                    LetrasCorretas.Add(entrada);
                }
            }
        }
        else
        {
            LetrasErradas.Add(entrada);
            Vidas -= 1;
        }
    }

    Console.Clear();
    Console.WriteLine(letras.ToString().Trim());
    Console.WriteLine("Letras corretas: " + string.Join(", ", LetrasCorretas));
    Console.WriteLine("Letras erradas: " + string.Join(", ", LetrasErradas));
    Console.WriteLine("Vidas restantes: " + Vidas);
}

if (!letras.ToString().Contains("_"))
{
    Console.WriteLine("Parabéns! Você adivinhou a palavra.");
}
else
{
    Console.WriteLine("Suas vidas acabaram. A palavra era: " + Palavra);
}
