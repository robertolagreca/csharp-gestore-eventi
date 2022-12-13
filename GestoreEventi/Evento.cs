using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        private string title;
        private string dateTimeEventString;
        private DateTime dateTimeEvent;
        private int totalSeats;
        private int bookedSeats;
        private int availableSeats;

        public Evento(string title, string dateTimeEventString, int totalSeats)
        {
            if (title == "" || title == " ")
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO NESSUN TITOLO");
            }
            if (DateTime.Parse(dateTimeEventString) < DateTime.Now)
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO NESSUNA DATA");
            }
            if (totalSeats <= 0)
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO IL NUMERO DI POSTI MASSIMO");
            }
            this.title = title;
            this.dateTimeEventString = dateTimeEventString;
            this.totalSeats = totalSeats;

            bookedSeats = 0;
            dateTimeEvent = DateTime.Parse(dateTimeEventString);
            availableSeats = totalSeats;
        }

        public string GetTitle () { return this.title; }
        public DateTime GetDate () { return this.dateTimeEvent; }
        public int GetTotalSeats () { return this.totalSeats;}
        public int GetBookedSeats () { return this.bookedSeats; }
        public int GetAvailableSeats () { return this.availableSeats; }

        //public int GetRemoveSeats() { return this.removeSeats; }

        public void SetTitle(string title) 
        { 
            if (title == "" || title == " ")
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO NESSUN TITOLO");
            }

            this.title = title;
        }
        public void SetData(DateTime dateTimeEvent) 
        { 
            if(dateTimeEvent < DateTime.Now)
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO NESSUNA DATA");
            }
            this.dateTimeEvent = dateTimeEvent; 
        }

        private void SetTotalSeats(int maxSeats)
        {
            if(maxSeats <= 0)
            {
                throw new ArgumentException("ATTENZIONE - NON HAI INSERITO IL NUMERO DI POSTI MASSIMO");
            }
            this.totalSeats = maxSeats;
        }
        public void SetBookedSeats(int bookedSeats)
        {
            if(bookedSeats > availableSeats)
            {
                throw new ArgumentException("ATTENZIONE - NON PUOI PRENOTARE PIU' POSTI DI QUELLI DISPONIBILI.");
            }
            this.bookedSeats = bookedSeats;
            this.availableSeats = availableSeats- bookedSeats;

        }

        public void SetAvailableSeats(int availableSeats)
        {
            this.availableSeats = availableSeats;
        }


        public void PrenotaPosti(int bookedSeats)
        {
            if(bookedSeats > availableSeats)
            {
                throw new ArgumentException("ATTENZIONE - NON PUOI PRENOTARE PIU' POSTI DI QUELLI DISPONIBILI");
            }

            if (dateTimeEvent <= DateTime.Now)
            {
                throw new ArgumentException("ATTENZIONE - PRENOTAZIONE BLOCCATA. L'EVENTO E' PASSATO O IN CORSO.");
            }

            this.bookedSeats = bookedSeats;
            this.availableSeats = availableSeats - bookedSeats;


        }

        public void DisdiciPosti(int removeSeats)
        {
            if (removeSeats > this.bookedSeats)
            {
                throw new ArgumentException("ATTENZIONE - NON PUOI DISDIRE PIU' POSTI DI QUELLI PRENOTATI.");
            }

            if (dateTimeEvent <= DateTime.Now)
            {
                throw new ArgumentException("ATTENZIONE - PRENOTAZIONE BLOCCATA. L'EVENTO E' PASSATO O IN CORSO.");
            }

            this.bookedSeats -= removeSeats;
            this.availableSeats += removeSeats;
        }

        public override string ToString()
        {
            //return base.ToString();
            return dateTimeEvent + " - " + title;
        }
    }
}
