using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GuildTracker
{
    class PlayerLoggingUDPClient
    {
        private IPEndPoint e;

        private UdpClient client;
        private bool connected = false;
        private static PlayerLoggingUDPClient instance = null;
        private class PlayerWrapper
        {
            char command;
            PlayerManagement.Player player;

            public PlayerWrapper()
            {

            }

            public PlayerWrapper(char command, PlayerManagement.Player aPlayer)
            {
                Command = command;
                Player = aPlayer;
            }

            public char Command
            {
                get
                {
                    return command;
                }
                set
                {
                    command = value;
                }
            }

            public PlayerManagement.Player Player
            {
                get
                {
                    return player;
                }

                set
                {
                    player = value;
                }
            }
        }

        public static void Send(char command, PlayerManagement.Player aPlayer)
        {
            GetInstance();
            if (instance.connected)
            {
                PlayerWrapper wrappedPlayer = new PlayerWrapper(command, aPlayer);
                string json = new JavaScriptSerializer().Serialize(wrappedPlayer);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(json);
                instance.client.Send(sendBytes, sendBytes.Length);
            }
        }

        private static void GetInstance()
        {
            if (instance == null)
                instance = new PlayerLoggingUDPClient();
        }

        public static void StartClient(string name, int port)
        {
            GetInstance();
            instance.client = new UdpClient();
            try
            {
                instance.client.Connect(name, port);
                instance.connected = true;
                instance.e = new IPEndPoint(IPAddress.Any, 0);
                instance.client.BeginReceive(new AsyncCallback(instance.ReceivedMessage), instance.e);
            }
            catch (Exception e)
            {
                instance.connected = false;
                throw e;
            }
        }

        public static void StopClient()
        {
            GetInstance();
            try
            {
                if (instance.connected)
                {
                    instance.client.Close();
                    instance.connected = false;
                }
            }
            catch
            {

            }
        }
        private void ReceivedMessage(IAsyncResult ar)
        {
            IPEndPoint endpoint = (IPEndPoint)(ar.AsyncState);
            try
            {
                if (!connected)
                    return;

                byte[] receivedBytes = instance.client.EndReceive(ar, ref endpoint);
                instance.client.BeginReceive(new AsyncCallback(ReceivedMessage), e);
                string json = Encoding.ASCII.GetString(receivedBytes);
                PlayerWrapper aWrappedPlayer = (PlayerWrapper)new JavaScriptSerializer().Deserialize(json, typeof(PlayerWrapper));
                if (aWrappedPlayer.Command == 'A')
                {
                    //  Add user.
                    PlayerManagement.AddPlayer(aWrappedPlayer.Player);
                }
                else if (aWrappedPlayer.Command == 'L')
                {
                    //  Update location.
                    PlayerManagement.GetPlayer(aWrappedPlayer.Player.Name).SetLocation(aWrappedPlayer.Player.Location.X, aWrappedPlayer.Player.Location.Y);
                }
                else if (aWrappedPlayer.Command == 'R')
                {
                    //  Remove user.
                    PlayerManagement.RemovePlayer(aWrappedPlayer.Player.Name);
                }
            }
            catch (SocketException se)
            {
                connected = false;
                instance.client.Close();
            }
        }

        private PlayerLoggingUDPClient()
        {
            
        }
    }
}
