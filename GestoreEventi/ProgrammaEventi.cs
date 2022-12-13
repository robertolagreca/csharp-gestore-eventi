using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        private string title;
        private List<Evento> events;

        public ProgrammaEventi(string title)
        {
            this.title = title;
            events = new List<Evento>();
        }


        public string GetTitleProgram() { return this.title; }

        public List<Evento> GetEvents() { return this.events; }


        public void AggiungiEvento(Evento evento)
        {
            events.Add(evento);
        }

        public void StampaEventiPerData(string date)
        {
            int i = 0;

            foreach(Evento evento in events)
            {
                if(DateTime.Parse(date) == evento.GetDate())
                {
                    Console.WriteLine(evento);
                    i++;
                }
            }
            if(i == 0)
            {
                Console.WriteLine("Non ci sono eventi programmati per la data " + date);
            }
        }

        public static void  StampaLista(List<Evento> listEvents)
        {
            if(listEvents.Count == 0)
            {
                Console.WriteLine("Gli elementi della lista sono stati cancellati");
            }
            else {

                foreach (Evento evento in listEvents)
                {
                    Console.WriteLine(evento);
                }
            }

           
        }

        public int NumeroEventi () 
        {
            return this.events.Count();
        }

        public void SvuotaEventi (List<Evento> listEvents)
        {
            listEvents.Clear();
            this.events = listEvents;
            ProgrammaEventi.StampaLista(events);
        }

        public static void PrintList(string title, List<Evento> events)
        {
             Console.WriteLine($"Titolo programma {title} \n\nData-----Eventi\n");

            ProgrammaEventi.StampaLista(events);
        }
    }
}
