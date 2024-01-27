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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPFLauncher.Manager;

namespace DotNetDetour.Manager.Utils
{
    internal class GameStart : IMethodHook
    {
        public static aqa gameManager = null;
        [HookMethod("WPFLauncher.Util.vl")]
        public static aqa a(string gta, string gtb, EventHandler gtc, apy gtd, string gte = null, bool gtf = false, Action<string> gtg = null)
        {
            SocketUtil.Send2Server(gtb);
            gtb = ReadFileArgs();
            GameStart.gameManager = GameStart.a_Original(gta, gtb, gtc, gtd, gte, gtf, gtg);
            new Thread(delegate ()
            {
                while (GameStart.gameManager.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(500);
                }
                SocketUtil.Send2Server("GameStartOK");
                while (!GameStart.gameManager.HasExited)
                {
                    Thread.Sleep(500);
                }
                SocketUtil.Send2Server("GameStartStop");
            }).Start();
            return GameStart.gameManager;
        }
        [OriginalMethod]
        public static aqa a_Original(string gta, string gtb, EventHandler gtc, apy gtd, string gte = null, bool gtf = false, Action<string> gtg = null)
        {
            return null;
        }
        public static string ReadFileArgs()
        {
            while (!File.Exists("C:\\GameStart.cache"))
            {
                Thread.Sleep(500);
            }
            string agrs = File.ReadAllText("C:\\GameStart.cache");
            File.Delete("C:\\GameStart.cache");
            return agrs;
        }
    }
}
