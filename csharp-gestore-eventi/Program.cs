using System.Globalization;

namespace csharp_gestore_eventi
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Inserisci il nome dell'evento: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci la data dell'evento (formato: dd/mm/yyyy): ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Inserisci il numero di posti totali: ");
            int capienzaMassima = int.Parse(Console.ReadLine());

            Evento evento = new Evento(titolo, data, capienzaMassima);

            Console.Write("Quanti posti vuoi prenotare? ");
            int postiDaPrenotare = int.Parse(Console.ReadLine());
            evento.PrenotaPosti(postiDaPrenotare);

            Console.WriteLine($"Posti prenotati: {evento.PostiPrenotati}");
            Console.WriteLine($"Posti disponibili: {evento.CapienzaMassima - evento.PostiPrenotati}");

            string input = "";
            while (true)
            {
                Console.Write("Vuoi disdire dei posti? (si/no) ");
                input = Console.ReadLine();

                if (input.ToLower() == "no")
                {
                    Console.Write("Ok va bene!");
                    break;
                }

                Console.Write("Quanti posti vuoi disdire? ");
                int postiDaDisdire = int.Parse(Console.ReadLine());
                evento.DisdiciPosti(postiDaDisdire);

                Console.WriteLine($"Posti prenotati: {evento.PostiPrenotati}");
                Console.WriteLine($"Posti disponibili: {evento.CapienzaMassima - evento.PostiPrenotati}");
            }
        }

    }
}