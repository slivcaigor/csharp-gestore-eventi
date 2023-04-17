using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        private string _relatore;
        private double _prezzo;

        public Conferenza(string titolo, DateTime data, int capienzaMassima, string relatore, double prezzo)
            : base(titolo, data, capienzaMassima)
        {
            _relatore = relatore;
            _prezzo = prezzo;
        }

        public string Relatore
        {
            get { return _relatore; }
            set { _relatore = value; }
        }

        public double Prezzo
        {
            get { return _prezzo; }
            set { _prezzo = value; }
        }

        public string PrezzoFormattato()
        {
            return Prezzo.ToString("0.00") + " euro";
        }

        public override string ToString()
        {
            return $"{Data:dd/MM/yyyy} - {Titolo} - {Relatore} - {PrezzoFormattato()} (Posti prenotati: {PostiPrenotati}, Posti disponibili: {CapienzaMassima - PostiPrenotati}/{CapienzaMassima})";
        }
    }

}
