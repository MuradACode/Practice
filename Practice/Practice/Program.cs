using Practice.Models;
using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Room room = new Room("Room 1", 50, 143, true);
            //Room room1 = new Room("Room 2", 70, 1, true);
            //Room roomm = new Room("Room 3", 45, 1);
            //Hotel hotel = new Hotel("name");
            //hotel.AddRoom(room);
            //hotel.AddRoom(room1);
            //Console.WriteLine(room.ToString());
            //Console.WriteLine(room1.ToString());
            //hotel.MakeReservation(1);
            Menu();
        }
        public static void Menu()
        {
            {
                string commands = "-----------------------------\n1: Create a Hotel\n2: See all hotels\n3: Add a room to selected hotel\n4: See rooms of hotel\n5: Make Reservation\n6: Exit\n-----------------------------";
                Console.WriteLine(@"
 ___       __   _______   ___       ________  ________  _____ ______   _______      
|\  \     |\  \|\  ___ \ |\  \     |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
\ \  \    \ \  \ \   __/|\ \  \    \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
 \ \  \  __\ \  \ \  \_|/_\ \  \    \ \  \    \ \  \\\  \ \  \\|__| \  \ \  \_|/__  
  \ \  \|\__\_\  \ \  \_|\ \ \  \____\ \  \____\ \  \\\  \ \  \    \ \  \ \  \_|\ \ 
   \ \____________\ \_______\ \_______\ \_______\ \_______\ \__\    \ \__\ \_______\
    \|____________|\|_______|\|_______|\|_______|\|_______|\|__|     \|__|\|_______|
                                                                                    
                                                                                    
                                                                                    
");
            Menu:
                Console.WriteLine("\n----------------------------------------\nChoose the command\nType 0 to get information about commands\n----------------------------------------");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine(commands);
                        goto Menu;
                    case "1":
                        Hotel.CreateHotelFromConsole();
                        goto Menu;
                    case "2":
                        Hotel.PrintHotel();
                        goto Menu;
                    case "3":
                        Hotel.AddRoomToSelectedHotel();
                        goto Menu;
                    case "4":
                        Hotel.SeeRoomsOfHotel();
                        goto Menu;
                    case "5":
                        Hotel.Reservation();
                        goto Menu;
                    case "6":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input try again!");
                        goto Menu;
                }
            }
        }
    }
}
