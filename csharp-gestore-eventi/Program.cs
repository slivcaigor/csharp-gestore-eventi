﻿using System.Globalization;

namespace csharp_gestore_eventi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome del tuo programma Eventi: ");
            string titoloProgramma = Console.ReadLine();
            ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

            Console.Write("Quanti eventi vuoi aggiungere? ");
            int numeroEventi = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < numeroEventi; i++)
            {
                try
                {
                    // Chiedo all'utente se vuole aggiungere un evento normale o una conferenza
                    Console.Write($"Di che tipo e' il {i + 1}° evento (evento/conferenza): ");
                    string tipoEvento = Console.ReadLine().ToLower();

                    Console.Write($"Inserisci il nome del {i + 1}° evento: ");
                    string titolo = Console.ReadLine();

                    Console.Write($"Inserisci la data dell'evento (formato: dd/mm/yyyy): ");
                    DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    Console.Write($"Inserisci il numero di posti totali: ");
                    int capienzaMassima = int.Parse(Console.ReadLine());

                    // Aggiungo un evento normale o una conferenza in base alla scelta dell'utente
                    if (tipoEvento == "evento")
                    {
                        Evento evento = new Evento(titolo, data, capienzaMassima);
                        programmaEventi.AggiungiEvento(evento);
                    }
                    else if (tipoEvento == "conferenza")
                    {
                        Console.Write("Inserisci il nome del relatore: ");
                        string relatore = Console.ReadLine();

                        Console.Write("Inserisci il prezzo della conferenza: ");
                        double prezzo = double.Parse(Console.ReadLine());

                        Conferenza conferenza = new Conferenza(titolo, data, capienzaMassima, relatore, prezzo);
                        programmaEventi.AggiungiEvento(conferenza);
                    }
                    else
                    {
                        Console.WriteLine("Tipo evento non valido, inserisci 'evento' o 'conferenza'.");
                        i--;
                        continue;
                    }
                    Console.Write("\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    i--;
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: Formato non valido.");
                    i--;
                    continue;
                }

                Evento currentEvento = programmaEventi.GetEvento(i);

                Console.Write($"Vuoi prenotare dei posti per l'evento {currentEvento.Titolo}? (si/no) ");
                string risposta = Console.ReadLine();

                if (risposta.ToLower() == "si")
                {
                    try
                    {
                        Console.Write($"Quanti posti vuoi prenotare per l'evento {currentEvento.Titolo}? ");
                        int postiDaPrenotare = int.Parse(Console.ReadLine());
                        currentEvento.PrenotaPosti(postiDaPrenotare);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }

                Console.Write($"Vuoi disdire dei posti per l'evento {currentEvento.Titolo}? (si/no) ");
                risposta = Console.ReadLine();

                if (risposta.ToLower() == "si")
                {
                    try
                    {
                        Console.Write($"Quanti posti vuoi disdire per l'evento {currentEvento.Titolo}? ");
                        int postiDaDisdire = int.Parse(Console.ReadLine());
                        currentEvento.DisdiciPosti(postiDaDisdire);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine($"Nel tuo programma ci sono {programmaEventi.NumeroEventi()} eventi");
            Console.WriteLine("Ecco la lista degli eventi inseriti:");
            Console.WriteLine(programmaEventi.ToString());

            Console.WriteLine("Inserisci una data per visualizzare gli eventi in quella data (formato: dd/mm/yyyy):");
            DateTime dataRicerca = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            List<Evento> eventiInData = programmaEventi.EventiInData(dataRicerca);

            Console.WriteLine($"Eventi in data {dataRicerca.ToString("dd/MM/yyyy")}:");
            Console.WriteLine(ProgrammaEventi.StampaEventi(eventiInData));
        }

    }
}