using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1PlayerTeam
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class OneDayTeam
    {
        private List<Player> players = new List<Player>();

        public void Add(Player player)
        {
            if (players.Count >= 11)
            {
                Console.WriteLine("Cannot add more than 11 players to the team.");
                return;
            }

            players.Add(player);
            Console.WriteLine("Player added successfully.");
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = players.Find(p => p.PlayerId == playerId);

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine("Player removed successfully.");
            }
            else
            {
                Console.WriteLine("Player not found with the given ID.");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return players.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return players.Find(p => p.Name == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return players;
        }
    }

    public class Program
    {
        public static void Main()
        {
            OneDayTeam team = new OneDayTeam();

            while (true)
            {
                Console.Write("Enter \n1:To Add Player \n2:To Remove Player by Id \n3:Get Player By Id \n4:Get Player by Name \n5:Get All Players \n");
                Console.WriteLine("Enter your Choice");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Player Id: ");
                        int playerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Player Name: ");
                        string playerName = Console.ReadLine();
                        Console.Write("Enter Player Age: ");
                        int playerAge = int.Parse(Console.ReadLine());

                        Player newPlayer = new Player
                        {
                            PlayerId = playerId,
                            Name = playerName,
                            Age = playerAge
                        };

                        team.Add(newPlayer);
                        break;
                    case 2:
                        Console.Write("Enter Player Id to Remove: ");
                        int removePlayerId = int.Parse(Console.ReadLine());
                        team.Remove(removePlayerId);
                        break;
                    case 3:
                        Console.Write("Enter Player Id to Get: ");
                        int getPlayerId = int.Parse(Console.ReadLine());
                        Player playerById = team.GetPlayerById(getPlayerId);
                        if (playerById != null)
                        {
                            Console.WriteLine(playerById.PlayerId + " " + playerById.Name + " " + playerById.Age);
                        }
                        else
                        {
                            Console.WriteLine("Player not found with the given ID.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter Player Name to Get: ");
                        string getPlayerName = Console.ReadLine();
                        Player playerByName = team.GetPlayerByName(getPlayerName);
                        if (playerByName != null)
                        {
                            Console.WriteLine(playerByName.PlayerId + " " + playerByName.Name + " " + playerByName.Age);
                        }
                        else
                        {
                            Console.WriteLine("Player not found with the given Name.");
                        }
                        break;
                    case 5:
                        List<Player> allPlayers = team.GetAllPlayers();
                        foreach (var player in allPlayers)
                        {
                            Console.WriteLine(player.PlayerId + " " + player.Name + " " + player.Age);
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;


                }
                Console.Write("Do you want to continue (yes/no)?:");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "yes")
                {
                    break;
                }
            }
        }
    }
}