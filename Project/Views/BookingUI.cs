using Project.Models;
using Project.ControllerInterface;
using Project.ViewsInterface;

namespace Project.Views
{
    public class BookingUI:IBookingUI
    {
        static int bookingId = Booking.BookingIdInc;

        public IBookingController BookingController { get; }
        public IEventController EventController { get; }
        public IEventUI EventUI { get; }

        public BookingUI(IBookingController bookingController, IEventController eventController, IEventUI eventUI)
        {
            BookingController = bookingController;  
            EventController = eventController;
            EventUI = eventUI;
        }
        public void BookTickets(string customerUsername) 
        {         
            var choosenEvent = ChooseEvent();
            var numOfTickets = EnterNumberOfTickets(choosenEvent);
            double totalprice = numOfTickets * choosenEvent.Price;
            var booking = new Booking(++bookingId, choosenEvent, customerUsername, numOfTickets, totalprice);
            BookingController.BookEvent(booking);
            EventController.DecrementTicket(choosenEvent, numOfTickets);
            Message.TicketsBooked();
        }


        private Event ChooseEvent()
        {
            EventUI.ViewEvents();
            Event bookedEvent;
            int eventId;
            while (true)
            {
                Console.Write(Message.EnterEventId);
                eventId = InputValidation.IntegerValidation();
                bookedEvent = EventController.GetById(eventId);
                if (bookedEvent == null)
                {
                    Console.WriteLine(Message.DoesNotExist);
                    Console.WriteLine();
                    continue;
                }
                if (bookedEvent.NumOfTicket == 0)
                {
                    Console.WriteLine(Message.NoTicketsAvailable);
                    continue;
                }
                break;
            }
            return bookedEvent;
        }

        private int EnterNumberOfTickets(Event bookedEvent)
        {
            int numOfTickets;
            while (true)
            {
                Console.Write(Message.EnterNumOfTickets);
                numOfTickets = InputValidation.IntegerValidation();
                if (numOfTickets < 0 || bookedEvent.NumOfTicket < numOfTickets)
                {
                    Console.WriteLine(Message.NotValidTickets);
                    continue;
                }
                break;
            }
            return numOfTickets;
        }
    }
}
