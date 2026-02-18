// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

Console.WriteLine("Quel est votre calcul ?");

var calculString = Console.ReadLine();

if (calculString == null) {
    Console.WriteLine("Erreur la valeur est null");
    return;
}

string pattern = @"^\s*(?<left>\d+?)\s*(?<op>[\+\-\/\*x])\s*(?<right>\d+?)\s*$";

Regex regex = new Regex(pattern);

Match match = regex.Match(calculString);

if (!match.Success)
{
    Console.WriteLine("Erreur dans la structure du calcul");
    return;
}

var left = int.Parse(match.Groups["left"].Value);
var right = int.Parse(match.Groups["right"].Value);
var op = match.Groups["op"].Value;

int result;


switch (op)
{
    case "+": result = left + right; break;
    case "-": result = left - right; break;
    case "/": result = left / right; break;
    default: result = left * right; break;
}

Console.WriteLine(result);

