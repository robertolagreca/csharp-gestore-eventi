using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string title;
        private DateTime dateTimeEvent;
        private int maxSeats;
        private int bookedSeats;
        private int availableSeats;
        private int requestSeats;
        private int removeSeats;

        public Evento(string title, DateTime dateTimeEvent, int bookedSeats)
        {
            bookedSeats = 0;
            this.title = title;
            this.dateTimeEvent = dateTimeEvent;
            this.bookedSeats = bookedSeats;

            availableSeats = maxSeats - bookedSeats;
        }

        public string GetTitle () { return this.title; }
        public DateTime GetData () { return this.dateTimeEvent; }
        public int GetMaxSeats () { return this.maxSeats;}
        public int GetBookedSeats () { return this.bookedSeats; }
        public int GetAvailableSeats () { return this.availableSeats; }

        //public int GetRequestSeats() { return this.requestSeats; }
        //public int GetRemoveSeats() { return this.removeSeats; }

        public void SetTitle(string title) 
        { 
            if (title == "" || title == " ")
            {
                throw new Exception("ATTENZIONE - NON HAI INSERITO NESSUN TITOLO");
            }

            this.title = title;
        }
        public void SetData(DateTime dateTimeEvent) 
        { 
            if(dateTimeEvent == DateTime.MinValue)
            {
                throw new Exception("ATTENZIONE - NON HAI INSERITO NESSUNA DATA");
            }
            this.dateTimeEvent = dateTimeEvent; 
        }

        private void SetMaxSeats(int maxSeats)
        {
            if(maxSeats <= 0)
            {
                throw new Exception("ATTENZIONE - NON HAI INSERITO IL NUMERO DI POSTI MASSIMO");
            }
            this.maxSeats = maxSeats;
        }
        public void SetBookedSeats(int bookedSeats)
        {
            this.bookedSeats = bookedSeats;
        }

        public void SetAvailableSeats(int availableSeats)
        {
            this.availableSeats = availableSeats;
        }

        public void SetRequestSeats(int requestSeats)
        {
            this.requestSeats= requestSeats;
        }

        public void SetRemoveSeats(int removeSeats)
        {
            this.removeSeats = removeSeats;
        }

        public void PrenotaPosti()
        {
            if(requestSeats > availableSeats)
            {
                throw new Exception("ATTENZIONE - NON PUOI PRENOTARE PIU' POSTI DI QUELLI DISPONIBILI");
            }

            if (dateTimeEvent <= DateTime.Now)
            {
                throw new Exception("ATTENZIONE - PRENOTAZIONE BLOCCATA. L'EVENTO E' PASSATO O IN CORSO.");
            }

            this.bookedSeats += requestSeats;
            
        }

        public void DisdiciPosti()
        {
            if (removeSeats > bookedSeats)
            {
                throw new Exception("ATTENZIONE - NON PUOI DISDIRE PIU' POSTI DI QUELLI PRENOTATI");
            }

            if (dateTimeEvent <= DateTime.Now)
            {
                throw new Exception("ATTENZIONE - PRENOTAZIONE BLOCCATA. L'EVENTO E' PASSATO O IN CORSO.");
            }

            this.bookedSeats -= removeSeats;
        }

        public override string ToString()
        {
            //return base.ToString();
            return Console.WriteLine($"{dateTimeEvent} - {title}");
        }
    }
}
