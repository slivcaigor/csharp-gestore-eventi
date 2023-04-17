using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        // Attributi
        public string Titolo { get; set; }
        private List<Evento> eventi;

        // Costruttore
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            eventi = new List<Evento>();
        }

        // Metodo per aggiungere un evento alla lista
        public void AggiungiEvento(Evento evento)
        {
            eventi.Add(evento);
        }

        // Metodo che restituisce gli eventi presenti in una data specifica
        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();
            foreach (Evento evento in eventi)
            {
                if (evento.Data.Date == data.Date)
                {
                    eventiInData.Add(evento);
                }
            }
            return eventiInData;
        }

        // Metodo statico per stampare gli eventi di una lista o restituire la rappresentazione in stringa della lista di eventi
        public static string StampaEventi(List<Evento> eventi)
        {
            string result = "";
            foreach (Evento evento in eventi)
            {
                result += evento.ToString() + "\n";
            }
            return result;
        }

        // Metodo che restituisce il numero di eventi presenti nel programma
        public int NumeroEventi()
        {
            return eventi.Count;
        }

        // Metodo per svuotare la lista di eventi
        public void SvuotaEventi()
        {
            eventi.Clear();
        }

        // Metodo che restituisce una rappresentazione in stringa del programma con tutti gli eventi aggiunti
        public override string ToString()
        {
            string result = $"Il tuo programma {Titolo}\n";
            foreach (Evento evento in eventi)
            {
                result += $"\t{evento}\n";
            }
            return result;
        }

        // Metodo per ottenere un evento in base all'indice
        public Evento GetEvento(int index)
        {
            return eventi[index];
        }
    }
}
