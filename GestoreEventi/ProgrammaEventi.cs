﻿using System;
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
            foreach(Evento evento in events)
            {
                if(DateTime.Parse(date) == evento.GetDate())
                {
                    Console.WriteLine(evento);
                }
            }
        }

        public static void  StampaLista(List<Evento> listEvents) 
        {
            foreach(Evento evento in listEvents)
            {
                Console.WriteLine(evento);
            }
        }

        public int NumeroEventi () 
        {
            return this.events.Count();
        }

        public void SvuotaEventi (List<Evento> listEvents)
        {
            listEvents.Clear();
        }

        public static void PrintList(string title, List<Evento> events)
        {
             Console.WriteLine("Titolo programma " + title + "\n Data-Eventi \n " + events);

        }
    }
}
