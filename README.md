# BookMyShow Console Application 🎬

BookMyShow Console Application is a simple event management and ticket booking system designed for Admins, Organizers, and Customers. The application utilizes JSON files for data storage.

## Types of Users

1. Admin 👩‍💼
2. Organizer 🧑‍🎤
3. Customer 🎫

## Functionalities

### Admin 👩‍💼

- Admin can view and add new admins.
- Admin can add organizers (organizers can't register themselves).
- Admin can view organizers.
- Admin can add customers and view customers.
- Admin can add venues and view venues.
- Admin can add artists and view artists.
- Admin can log in to the application.
- Admin can add an event, view all events, and cancel an event.
- Admin can add a booking and view all bookings.

### Organizer 🧑‍🎤

- Organizers can log in to the application.
- Organizers can create an event by selecting artists and venues provided by the admin.
- Organizers can cancel an event.
- Organizers can view their previously created events.

### Customer 🎫

- Customers can register/login to the application.
- Customers can browse available events.
- Customers can book tickets.
- Customers can view their previously bought tickets.

## Data Storage 🗃️

The application uses JSON files for data storage. Each user type (Admin, Organizer, Customer) and entities such as events, bookings, artists, venues, etc., are stored in separate JSON files.

## Unit Testing 🧪

The controllers and core functionalities of the application have been thoroughly unit-tested to ensure reliability and correctness. You can find the unit tests in the `Tests` directory.

## Getting Started 🚀

1. Clone the repository: `git clone https://github.com/your-username/BookMyShowConsoleApp.git`
2. Navigate to the project directory: `cd BookMyShowConsoleApp`
