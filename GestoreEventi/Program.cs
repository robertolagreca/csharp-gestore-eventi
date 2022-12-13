// See https://aka.ms/new-console-template for more information

using GestoreEventi;

string title = "";
string dateTimeEventString;
string confirmRemovingSeats = "no";
int totalSeats = 0;
int bookedSeats = 0;
int removeSeats = 0;
bool checkRemoveSeats = false;



Console.WriteLine("Inserire i dati richiesti:");
Console.WriteLine("Titolo");
title = Console.ReadLine();
Console.WriteLine("Data dell'evento");
dateTimeEventString = Console.ReadLine();
Console.WriteLine("Posti totali per l'evento");
totalSeats = int.Parse(Console.ReadLine());

Evento eventObj = new Evento(title, dateTimeEventString, totalSeats);




Console.WriteLine("Inserisci il numero di posti da riservare con prenotazione:");
bookedSeats= int.Parse(Console.ReadLine());
eventObj.PrenotaPosti(bookedSeats);

Console.WriteLine("Posti prenotati: " + eventObj.GetBookedSeats() + " - Posti disponibili "+ eventObj.GetAvailableSeats());


do
{
    Console.WriteLine("Desideri disdire dei posti prenotati. si/no");
    confirmRemovingSeats = Console.ReadLine();

    if (confirmRemovingSeats.ToLower() == "si")
    {
        checkRemoveSeats = true;
        Console.WriteLine("Quanti posti vuoi disdire. Inserisci il numero.");
        removeSeats = int.Parse(Console.ReadLine());

        eventObj.DisdiciPosti(removeSeats);
        Console.WriteLine("Posti prenotati: " + eventObj.GetBookedSeats() + " - Posti disponibili " + eventObj.GetAvailableSeats());
    } else
    {
        checkRemoveSeats = false;
    }
} while (checkRemoveSeats);



