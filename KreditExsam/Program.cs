using KreditExsam;
using KreditExsam.Models;
using KreditExsam.Service;

Console.Write("OylikMaosh = ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("KundalikTulov = ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("KreditSumma = ");
int c = Convert.ToInt32(Console.ReadLine());
Console.Write("KreditMuddat = ");
int d = Convert.ToInt32(Console.ReadLine());
Console.Write("KredFoiz = ");
int e = Convert.ToInt32(Console.ReadLine());

KreditClass kredit = new KreditClass(a, b, c, d, e);

IKreditService service = new KreditService();

var kreditValue = await service.KREDIT_GETS(kredit);

if (kreditValue.Count == 0)
{
    Console.Write("NO Credit plase !");
}
else 
{
    foreach (var item in kreditValue)
    {
        Console.Write("Oyi = " + item.Oy + " CreditBalansi = " + Math.Round(item.CreditBalansi, 2) + " AsosiyQarzi = " +Math.Round(item.AsosiyQarzi, 2) + " Foizi = " +Math.Round(item.Foizi) + " JamiOylikTulov = " +Math.Round(item.JamiOylikTulov, 2));
        Console.WriteLine();
    }
}

Console.ReadKey();