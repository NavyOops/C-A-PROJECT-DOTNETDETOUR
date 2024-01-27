/*
 *    Copyright 2024 NAVYOOPS

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WPFLauncher.Model.Game.CppGame;
using WPFLauncher.Util;

namespace DotNetDetour.Manager.Utils
{
    public class SocketUtil
    {

        //Double Client Connect the Server
        public static Socket socket = null;
        //InitSocket     1.Ipv4 2.流式传输 3.TCP (*UDP)
        public static Socket Buffersocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //Buffers     getClientData     0.25mb
        public static byte[] buffers = new byte[1024 * 1024 * 2];


        //SendClient
        public static bool PropetyTCP()
        {
            if (socket == null)
            {
                Thread receive = new Thread(Receive_ToServer);
                receive.Start();
            }
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 23523);
            return socket.Connected;
        }

        //Send To Server
        public static void Send2Server(string send)
        {
            byte[] sendByte = Encoding.UTF8.GetBytes(send);

            if (PropetyTCP() && socket != null)
            {
                Console.WriteLine(send);
                socket.Send(sendByte, sendByte.Length, SocketFlags.None);
                socket.Close();
            }
        }

        //ReciveClient
        public static void Receive_ToServer()
        {
            Buffersocket.Connect("127.0.0.1", 23523);

            Thread thread = new Thread(new ThreadStart(targett));
            thread.Start();

        }


        //Socket Data ReSend
        private static void targett()
        {
            int count = SocketUtil.Buffersocket.Receive(SocketUtil.buffers);
            string @string = Encoding.UTF8.GetString(SocketUtil.buffers, 0, count);
            string[] array = Regex.Split(@string, "&", RegexOptions.IgnoreCase);
            try
            {
                SocketUtil.buffers = new byte[2097152];
                Thread thread = new Thread(new ThreadStart(SocketUtil.targett));
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
