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

        // Metodo per prenotare posti
        public void PrenotaPosti(int numeroPosti)
        {
            if (_data < DateTime.Now)
            {
                throw new InvalidOperationException("L'evento si è già concluso.");
            }

            if (numeroPosti <= 0 || _postiPrenotati + numeroPosti > _capienzaMassima)
            {
                throw new InvalidOperationException("Non ci sono abbastanza posti disponibili.");
            }

            _postiPrenotati += numeroPosti;
        }

        // Metodo per disdire posti
        public void DisdiciPosti(int numeroPosti)
        {
            if (_data < DateTime.Now)
            {
                throw new InvalidOperationException("L'evento si è già concluso.");
            }

            if (numeroPosti <= 0 || _postiPrenotati - numeroPosti < 0)
            {
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire.");
            }

            _postiPrenotati -= numeroPosti;
        }

        // Override del metodo ToString
        public override string ToString()
        {
            return _data.ToString("dd/MM/yyyy") + " - " + _titolo;
        }
    }
}
