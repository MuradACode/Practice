using Practice.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        private Room[] _rooms = new Room[0];
        public static Hotel[] hotels;

        static Hotel()
        {
            hotels = new Hotel[0];
        }
        public Hotel()
        {
            Array.Resize(ref hotels, hotels.Length + 1);
            hotels[^1] = this;
        }
        public Hotel(string name) : this()
        {
            Name = name;
        }
        public void AddRoom(Room room)
        {
            Array.Resize(ref _rooms, _rooms.Length + 1);
            _rooms[^1] = room;
        }
        public void MakeReservation(int? roomId)
        {
            if (roomId is null) throw new NotAvailableException("Room's id can't be null");
            if (Array.Exists(_rooms, n => n.Id == roomId))
            {
                    Room room = Array.Find(_rooms, n => n.Id == roomId);
                    int index = Array.IndexOf(_rooms, room);
                    if (_rooms[index].IsAvailable is false) throw new NotAvailableException("Room is not available");
                    else if (_rooms[index].IsAvailable is true) _rooms[index].IsAvailable = false;
            }
            else throw new NotAvailableException("Room doesn't exist");
        }
        public static void CreateHotelFromConsole()
        {
            Console.Clear();
            Console.WriteLine(@"
   ____                _                 _   _       _       _ 
  / ___|_ __ ___  __ _| |_ ___    __ _  | | | | ___ | |_ ___| |
 | |   | '__/ _ \/ _` | __/ _ \  / _` | | |_| |/ _ \| __/ _ \ |
 | |___| | |  __/ (_| | ||  __/ | (_| | |  _  | (_) | ||  __/ |
  \____|_|  \___|\__,_|\__\___|  \__,_| |_| |_|\___/ \__\___|_|
                                                               
");
        TryHotelName:
            Console.Write("Type the name of hotel: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryHotelName;
            }
            Hotel hotel = new Hotel(name);

            Console.WriteLine("----------------------------------------\nHotel created successfully\n----------------------------------------");
        }
        public static void PrintHotel()
        {
            Console.Clear();
            Console.WriteLine(@"
  ____                    _ _   _           _       _     
 / ___|  ___  ___    __ _| | | | |__   ___ | |_ ___| |___ 
 \___ \ / _ \/ _ \  / _` | | | | '_ \ / _ \| __/ _ \ / __|
  ___) |  __/  __/ | (_| | | | | | | | (_) | ||  __/ \__ \
 |____/ \___|\___|  \__,_|_|_| |_| |_|\___/ \__\___|_|___/
                                                          
");
            for (int i = 0; i < hotels.Length; i++)
            {
                Console.WriteLine(i+1+") Hotel's name: " + hotels[i].Name);
            }
        }
        public static void AddRoomToSelectedHotel()
        {
            Console.Clear();
            Console.WriteLine(@"
     _       _     _                                       _                   _           _           _   _           _       _ 
    / \   __| | __| |   __ _   _ __ ___   ___  _ __ ___   | |_ ___    ___  ___| | ___  ___| |_ ___  __| | | |__   ___ | |_ ___| |
   / _ \ / _` |/ _` |  / _` | | '__/ _ \ / _ \| '_ ` _ \  | __/ _ \  / __|/ _ \ |/ _ \/ __| __/ _ \/ _` | | '_ \ / _ \| __/ _ \ |
  / ___ \ (_| | (_| | | (_| | | | | (_) | (_) | | | | | | | || (_) | \__ \  __/ |  __/ (__| ||  __/ (_| | | | | | (_) | ||  __/ |
 /_/   \_\__,_|\__,_|  \__,_| |_|  \___/ \___/|_| |_| |_|  \__\___/  |___/\___|_|\___|\___|\__\___|\__,_| |_| |_|\___/ \__\___|_|
                                                                                                                                 
");
            HotelTry:
            Console.WriteLine("Select the hotel:");
            PrintHotel();
            string input = Console.ReadLine().Trim();
            int select = 0;
            for (int i = 0; i < hotels.Length; i++)
            {
                if (input == hotels[i].Name)
                {
                    Console.WriteLine("Hotel selected");
                    select = i;
                    break;
                }
                else
                {
                    Console.WriteLine("This hotel does not exist\nTry again!");
                    goto HotelTry;
                }
            }
        TryRoomName:
            Console.Write("Type the name of the room: ");
            string roomName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(roomName))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryRoomName;
            }
        TryPrice:
            Console.Write("How much does this room cost? : ");
            int price;
            try
            {
                price = Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryPrice;
            }
        TryPersonCapacity:
            Console.Write("For how many people is this room for?: ");
            int personCapacity;
            try
            {
                personCapacity = Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryPersonCapacity;
            }
        TryAvailable:
            Console.Write("Is this room available now?\t(Type 'y' if yes or 'n' if not): ");
            bool isAvailable;
            string available = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(available))
            {
                Console.Clear();
                Console.WriteLine("It can't be empty!");
                goto TryAvailable;
            }
            if (available == "y") isAvailable = true;
            else if (available == "n") isAvailable = false;
            else
            {
                Console.WriteLine("Invalid input try again!");
                goto TryAvailable;
            }
            Room room = new Room(roomName, price, personCapacity, isAvailable);
            hotels[select].AddRoom(room);
            Console.WriteLine("----------------------------------------\nRoom created successfully\n----------------------------------------");
            
        }
        public static void SeeRoomsOfHotel()
        {
            Console.Clear();
            Console.WriteLine(@"
  ____                                                     __   _           _       _ 
 / ___|  ___  ___   _ __ ___   ___  _ __ ___  ___    ___  / _| | |__   ___ | |_ ___| |
 \___ \ / _ \/ _ \ | '__/ _ \ / _ \| '_ ` _ \/ __|  / _ \| |_  | '_ \ / _ \| __/ _ \ |
  ___) |  __/  __/ | | | (_) | (_) | | | | | \__ \ | (_) |  _| | | | | (_) | ||  __/ |
 |____/ \___|\___| |_|  \___/ \___/|_| |_| |_|___/  \___/|_|   |_| |_|\___/ \__\___|_|
                                                                                      
");
        HotelSelectTry:
            Console.WriteLine("Select the hotel:");
            PrintHotel();
            string input = Console.ReadLine();
            for (int i = 0; i < hotels.Length; i++)
            {
                if (input == hotels[i].Name)
                {
                    for (int n = 0; n < hotels[i]._rooms.Length; n++)
                    {
                        Console.WriteLine("Rooms:\n" + hotels[i]._rooms[n].ToString() + "\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("This hotel does not exist\nTry again!");
                    goto HotelSelectTry;
                }
            }
        }
        public static void Reservation()
        {
            Console.Clear();
            Console.WriteLine(@"
  __  __       _          ____                                _   _             
 |  \/  | __ _| | _____  |  _ \ ___  ___  ___ _ ____   ____ _| |_(_) ___  _ __  
 | |\/| |/ _` | |/ / _ \ | |_) / _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \ 
 | |  | | (_| |   <  __/ |  _ <  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |
 |_|  |_|\__,_|_|\_\___| |_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|
                                                                                
");
        HotelReserveSelectTry:
            Console.WriteLine("Select the hotel:");
            PrintHotel();
            int selectedHotel = 0;
            int selectedRoom = 0;
            string input = Console.ReadLine().Trim();
            for (int i = 0; i < hotels.Length; i++)
            {
                if (input == hotels[i].Name)
                {
                    selectedHotel = i;
                    int roomInput = 0;
                    TryRoomId:
                    for (int n = 0; n < hotels[i]._rooms.Length; n++)
                    {
                        Console.WriteLine("Room's IDs:\n" + hotels[i]._rooms[n].Id + "\n");
                        Console.WriteLine("Select the room ID:");
                        try
                        {
                            roomInput = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again!");
                            goto TryRoomId;
                        }
                        if (roomInput == hotels[i]._rooms[n].Id)
                        {
                            selectedRoom = n;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("This hotel does not exist\nTry again!");
                    goto HotelReserveSelectTry;
                }
            }
            hotels[selectedHotel].MakeReservation(hotels[selectedHotel]._rooms[selectedRoom].Id);
            Console.WriteLine("----------------------------------------\nRoom reserved successfully\n----------------------------------------");
        }
    }
}
