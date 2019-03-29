using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildTracker
{
    class PlayerManagement
    {
        public class PlayerClass
        {
            public PlayerClass()
            {
            }
            public enum classType
            {
                Cleric=0, 
                Shaman,
                Wizard,
                Monk,
                Magician,
                Enchanter,
                Warrior,
                ShadowKnight,
                Paladin,
                Necromancer,
                Rogue,
                Druid,
                Bard,
                Ranger,
                Unknown
            }

            private classType type;

            public classType Type
            {
                get
                {
                    return type;
                }
                set
                {
                    type = value;
                }
            }

            public PlayerClass(string name)
            {
                if ((name == "Minstril") ||
                    (name == "Troubadour") ||
                    (name == "Virtuoso") ||
                    (name == "Bard"))
                {
                    type = classType.Bard;
                    return;
                }
                if ((name == "Vicar") ||
                    (name == "Templar") ||
                    (name == "High Priest") ||
                    (name == "Cleric"))
                {
                    type = classType.Cleric;
                    return;
                }
                if ((name == "Wanderer") ||
                    (name == "Preserver") ||
                    (name == "Hierophant") ||
                    (name == "Druid"))
                {
                    type = classType.Druid;
                    return;
                }
                if ((name == "Illusionist") ||
                    (name == "Beguiler") ||
                    (name == "Phantasnist") ||
                    (name == "Enchanter"))
                {
                    type = classType.Enchanter;
                    return;
                }
                if ((name == "Elementalist") ||
                    (name == "Conjurer") ||
                    (name == "Arch Mage") ||
                    (name == "Magician"))
                {
                    type = classType.Magician;
                    return;
                }
                if ((name == "Disciple") ||
                    (name == "Master") ||
                    (name == "Grandmaster") ||
                    (name == "Monk"))
                {
                    type = classType.Monk;
                    return;
                }
                if ((name == "Heretic") ||
                    (name == "Defiler") ||
                    (name == "Warlock") ||
                    (name == "Necromancer"))
                {
                    type = classType.Necromancer;
                    return;
                }
                if ((name == "Cavalier") ||
                    (name == "Knight") ||
                    (name == "Crusader") ||
                    (name == "Paladin"))
                {
                    type = classType.Paladin;
                    return;
                }
                if ((name == "Pathfinder") ||
                    (name == "Outrider") ||
                    (name == "Warder") ||
                    (name == "Ranger"))
                {
                    type = classType.Ranger;
                    return;
                }
                if ((name == "Rake") ||
                    (name == "Blackguard") ||
                    (name == "Assassin") ||
                    (name == "Rogue"))
                {
                    type = classType.Rogue;
                    return;
                }
                if ((name == "Reaver") ||
                    (name == "Revenant") ||
                    (name == "Grave Lord") ||
                    (name == "ShadowKnight"))
                {
                    type = classType.ShadowKnight;
                    return;
                }
                if ((name == "Mystic") ||
                    (name == "Luminary") ||
                    (name == "Oracle") ||
                    (name == "Shaman"))
                {
                    type = classType.Shaman;
                    return;
                }
                if ((name == "Champion") ||
                    (name == "Myrmidon") ||
                    (name == "Warlord") ||
                    (name == "Warrior"))
                {
                    type = classType.Warrior;
                    return;
                }
                if ((name == "Channeler") ||
                    (name == "Evoker") ||
                    (name == "Sorcerer") ||
                    (name == "Wizard"))
                {
                    type = classType.Wizard;
                    return;
                }
                throw new Exception("Bad class name.");
            }
            public override string ToString()
            {
                string classAsString;
                switch (Type)
                {
                    case classType.Bard:
                        classAsString = "Bard";
                        break;
                    case classType.Cleric:
                        classAsString = "Cleric";
                        break;
                    case classType.Druid:
                        classAsString = "Druid";
                        break;
                    case classType.Enchanter:
                        classAsString = "Enchanter";
                        break;
                    case classType.Magician:
                        classAsString = "Magician";
                        break;
                    case classType.Monk:
                        classAsString = "Monk";
                        break;
                    case classType.Necromancer:
                        classAsString = "Necromancer";
                        break;
                    case classType.Paladin:
                        classAsString = "Paladin";
                        break;
                    case classType.Ranger:
                        classAsString = "Ranger";
                        break;
                    case classType.Rogue:
                        classAsString = "Rogue";
                        break;
                    case classType.ShadowKnight:
                        classAsString = "Shadow Knight";
                        break;
                    case classType.Shaman:
                        classAsString = "Shaman";
                        break;
                    case classType.Warrior:
                        classAsString = "Warrior";
                        break;
                    case classType.Wizard:
                        classAsString = "Wizard";
                        break;
                    default:
                        classAsString = "Unknown";
                        break;
                }
                return classAsString;
            }
        }

        public class Player
        {
            private PlayerClass playerClass;
            private string name;
            private Int16 level;
            private string zone;
            private Location location;

            public short Level
            {
                get
                {
                    return level;
                }

                set
                {
                    level = value;
                }
            }

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public string Zone
            {
                get
                {
                    return zone;
                }

                set
                {
                    zone = value;
                }
            }

            public Location Location
            {
                get
                {
                    return location;
                }
                set
                {
                    location = value;
                }
            }

            public PlayerClass PlayerClass
            {
                get
                {
                    return playerClass;
                }
                set
                {
                    playerClass = value;
                }
            }

            public Player()
            {
                this.Name = null;
                this.Zone = null;
                this.Level = 0;
                this.location = null;
                playerClass = null;
            }

            public Player(string name, string zone, string className = null, Int16 level = 0, Location location = null)
            {
                this.Name = name;
                this.Zone = zone;
                this.Level = level;
                this.location = location;
                if (className != null)
                    playerClass = new PlayerClass(className);
            }

            public void SetClass(string className)
            {
                playerClass = new PlayerClass(className);
            }

            public string GetClassName()
            {
                return PlayerClass.ToString();
            }

            public void SetLocation(double x, double y)
            {
                if (location == null)
                    location = new Location(x, y);
                else
                {
                    Location.X = x;
                    Location.Y = y;
                }
                OnLocationChanged?.Invoke(name, location);
            }
        }

        public class Location
        {
            private double x;
            private double y;

            public Location()
            {
                x = 0;
                y = 0;
            }

            public Location(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public double X
            {
                get
                {
                    return x;
                }

                set
                {
                    x = value;
                }
            }

            public double Y
            {
                get
                {
                    return y;
                }

                set
                {
                    y = value;
                }
            }
        }

        private Dictionary<string, Player> players;
        private Dictionary<string, SolidBrush> brushes;

        private static PlayerManagement instance = null;
        private Random rnd = null;


        //  Events
        public delegate void PlayerAddedHandler(Player aPlayer);
        public static event PlayerAddedHandler OnPlayerAadded = null;

        public delegate void PlayerRemovedHandler(Player aPlayer);
        public static event PlayerRemovedHandler OnPlayerRemoved = null;

        public delegate void PlayerLocationHandler(string name, Location aLocation);
        public static event PlayerLocationHandler OnLocationChanged = null;

        public static void AddPlayer(Player aPlayer)
        {
            GetInstance();
            if (aPlayer == null)
                return;
            if (!instance.brushes.ContainsKey(aPlayer.Name))
                instance.brushes.Add(aPlayer.Name, new SolidBrush(Color.FromArgb(instance.rnd.Next(256), instance.rnd.Next(256), instance.rnd.Next(256))));
            instance.players[aPlayer.Name] = aPlayer;
            OnPlayerAadded?.Invoke(aPlayer);
        }

        public static void AddPlayer(string name, string zone, string className = null, Int16 level = 0)
        {
            GetInstance();

            if (instance.players.ContainsKey(name))
            {
                instance.players[name].Level = level;
                if (className != null)
                    instance.players[name].SetClass(className);
            }
            else
            {
                instance.players[name] = new Player(name, zone, className, level);
                instance.brushes.Add(name, new SolidBrush(Color.FromArgb(instance.rnd.Next(256), instance.rnd.Next(256), instance.rnd.Next(256))));
            }
            OnPlayerAadded?.Invoke(instance.players[name]);
        }

        public static Brush GetBrush(string name)
        {
            GetInstance();
            return (instance.brushes.ContainsKey(name))?instance.brushes[name]:null;
        }

        private static void GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerManagement();
            }
        }

        public static void RemovePlayer(string name)
        {
            GetInstance();

            if (instance.players.ContainsKey(name))
            {
                Player aPlayer = instance.players[name];
                instance.players.Remove(name);
                OnPlayerRemoved?.Invoke(aPlayer);
            }
        }

        public static ICollection<Player> GetPlayers()
        {
            GetInstance();

            return instance.players.Values;
        }

        public static Player GetPlayer(string name)
        {
            GetInstance();

            if (instance.players.ContainsKey(name))
                return instance.players[name];
            else
                return null; 
        }

        private PlayerManagement()
        {
            players = new Dictionary<string, Player>();
            brushes = new Dictionary<string, SolidBrush>();
            rnd = new Random();
        }
    }
}
