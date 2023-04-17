using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        // Attributi privati
        private string _titolo;
        private DateTime _data;
        private int _capienzaMassima;
        private int _postiPrenotati;

        // Costruttore
        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;

            if (capienzaMassima <= 0)
            {
                throw new ArgumentException("Il numero di posti totali deve essere valido");
            }
            _capienzaMassima = capienzaMassima;
            _postiPrenotati = 0;
        }

        // Metodi Getter e Setter per titolo
        public string Titolo
        {
            get { return _titolo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Il titolo non può essere vuoto.");
                }
                _titolo = value;
            }
        }

        // Metodi Getter e Setter per data
        public DateTime Data
        {
            get { return _data; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Inserisci una data valida");
                }
                _data = value;
            }
        }

        // Metodo Getter per capienza massima
        public int CapienzaMassima
        {
            get { return _capienzaMassima; }
        }

        // Metodo Getter per posti prenotati
        public int PostiPrenotati
        {
            get { return _postiPrenotati; }
        }
    }
}
