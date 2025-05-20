namespace BR_5_LEKCE;

// Definice Banky
public class Banka
{
    public string Symbol { get; set; }
    public string Jmeno { get; set; }
}

// Definice Zákazníka
public class Zakaznik
{
    public string Jmeno { get; set; }
    public double Zustatek { get; set; }
    public string Banka { get; set; }
}

// Definice Skupiny milionářů
public class SkupinaMilionaru
{
    public string Banka { get; set; }
    public IEnumerable<string> Milionari { get; set; }
}

public class Program
{
    public static void Main()
    {
        // ==========================================
        // 1. Nalezněte slova začínající písmenem 'M'
        List<string> ovoce = new List<string>() { "Merunka", "Jablko", "Pomeranc", "Meloun", "Malina", "Limetka" };


        /*------Je nejaky zasadni rozdil v techto trech zapisech?-----*/
        var mOvoce = ovoce.Where(o => o.StartsWith("M"));
        //List<string> mOvoce1 = ovoce.Where(o => o.StartsWith("M")).ToList();
        //List<string> mOvoce2 = ovoce.FindAll(o => o.StartsWith("M"));

        foreach (var o in mOvoce)
        {
            Console.WriteLine(o);
        }
 
        // ==========================================		
        // 2. Která z následujících čísel jsou násobky 4 nebo 6
        List<int> ruznaCisla = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        // var ruzneNasobky = ruznaCisla.Where(r => (r % 4 == 0) || (r % 6 == 0)); 
        //List<int> ruzneNasobky2 = ruznaCisla.Where(r => (r % 4 == 0) || (r % 6 == 0)).ToList();

        foreach (var r in ruznaCisla) // in ruzneNasobky
        {
            if ((r % 4 == 0) || (r % 6 == 0))
            {
                Console.WriteLine(r);
            }
        }

        // 3. Kolik je v seznamu ruznaCisla čísel?

        Console.WriteLine(ruznaCisla.Count());

        // ==========================================
        // 4. Seřaďte jména vzestupně

        List<string> jmena = new List<string>()
        {
            "Hana", "Jaroslav", "Xenie", "Michaela", "Borivoj", "Nela",
            "Katerina", "Sofie", "Adam", "David", "Zuzana", "Barbara",
            "Tereza", "Lenka", "Svetlana", "Cecilie", "Renata",
            "Evzen", "Pavel", "Eliska", "Viktor", "Antonin",
            "Frantisek", "Radek"
        };

        List<string> jmenaRazeni = jmena.OrderBy(j => j).ToList();

        foreach (string j in jmenaRazeni)
        {
            Console.WriteLine(j);
        }

        /* List<string> vzestupne = jmena.Order().ToList(); // Vychozi porovnani je alfabeticke, jinak bychom museli implementovat vlastni IComparer

		foreach (string text in vzestupne)
		{
			Console.WriteLine(text);
		} */
        /* foreach (var j in jmena.OrderBy(j => j))
        {
            Console.WriteLine(j);
        } */

        // ==========================================
        // 5. Kolik je celkový součet?
        List<double> utrata = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };

        var sectiCisla = utrata.Sum();
        Console.WriteLine(sectiCisla);

        // 5. Řešení
        // Console.WriteLine(?????);

        // ==========================================		
        // 6. Jaké je největší cena?
        List<double> cena = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };

        Console.WriteLine(cena.Max());

        // ==========================================		
        // 7. Zobrazte vsechny milionare v kazde bance
        // Napr. 
        // CS: Jan Novak a Josef Novotny
        // KB: Jana Nova

        List<Zakaznik> zakaznici = new List<Zakaznik>() {
                new Zakaznik(){ Jmeno="Jan Maly", Zustatek=10345.50, Banka="CS"},
                new Zakaznik(){ Jmeno="Jiri Hladny", Zustatek=452.10, Banka="KB"},
                new Zakaznik(){ Jmeno="Lenka Sporiva", Zustatek=523665.13, Banka="CS"},
                new Zakaznik(){ Jmeno="Marie Bohata", Zustatek=7482184.38, Banka="FIO"},
                new Zakaznik(){ Jmeno="Michal Marny", Zustatek=745234.93, Banka="KB"},
                new Zakaznik(){ Jmeno="Lada Vychytraly", Zustatek=8832937.34, Banka="CS"},
                new Zakaznik(){ Jmeno="Sandra Nedostatecna", Zustatek=942488.48, Banka="KB"},
                new Zakaznik(){ Jmeno="Silvie Zavodou", Zustatek=56198334.72, Banka="FIO"},
                new Zakaznik(){ Jmeno="Tereza Presna", Zustatek=1000000.00, Banka="CITI"},
                new Zakaznik(){ Jmeno="Stefan Pilny", Zustatek=48282.73, Banka="CITI"}
            };

        List<SkupinaMilionaru> skupinyPodleBanky = zakaznici
        .Where(z => z.Zustatek >= 1000000) // Vyfiltruji milionare
        .GroupBy(z => z.Banka) // Vytvorim grouping pro kazdou banku
        .Select(grouping => new SkupinaMilionaru()
        { // Kazdy grouping prevedu na SkupinaMilionaru
            Banka = grouping.Key,
            Milionari = grouping.Select(g => g.Jmeno)
        })
        .ToList();

        foreach (var polozka in skupinyPodleBanky)
        {
            Console.WriteLine(polozka.Banka + ": " + string.Join(" a ", polozka.Milionari));
        }

        // ==========================================		
        // 8. Vytisknete jmeno kazdeho milionare a jeho banky
        // Napr
        // Jan Novak v Ceska Sporitelna
        // Josef Novotny v Komercni Banka
        List<Banka> banky = new List<Banka>() {
                        new Banka(){ Jmeno="Ceska Sporitelna", Symbol="CS"},
                        new Banka(){ Jmeno="Komercni Banka", Symbol="KB"},
                        new Banka(){ Jmeno="Fio Banka", Symbol="FIO"},
                        new Banka(){ Jmeno="Citibank", Symbol="CITI"},
                    };
                    
                    List<Zakaznik> milionari = zakaznici.Where(z => z.Zustatek >= 1000000).ToList();

		List<Zakaznik> reportMilionaru = milionari.Join( // milionari jsou outer neboli "vnejsi" kolekce
			inner: banky, // banky jsou "vnitrni" kolekce
			outerKeySelector: milionar => milionar.Banka, // milionare a banky spojim pomoci sdileneho klice, coz je symbol banky
			innerKeySelector: banka => banka.Symbol,
			resultSelector: (milionar, banka) => new Zakaznik() { // vytvorim noveho zakaznika, akorat misto symbolu banku vyberu jeji jmeno
				Jmeno = milionar.Jmeno,
				Zustatek = milionar.Zustatek,
				Banka = banka.Jmeno
			}
		).ToList();

		foreach (Zakaznik zakaznik in reportMilionaru)
		{
			Console.WriteLine(zakaznik.Jmeno + " v " + zakaznik.Banka);
		}

		IEnumerable<Zakaznik> reportMilionaruPresQuery = // reseni pomoci LINQ query
			from milionar in milionari
			join banka in banky on milionar.Banka equals banka.Symbol
			select new Zakaznik
			{
				Jmeno = milionar.Jmeno,
				Zustatek = milionar.Zustatek,
				Banka = banka.Jmeno
			};
	}
}

