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
using DotNetDetour.Manager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLauncher.View.WebPage;

namespace DotNetDetour.Manager
{
    internal class AddressCheck : IMethodHook
    {
        [HookMethod("WPFLauncher.Manager.Log.Util.asd")]
        public static string b()
        {
            var mac = randomMac();
            SocketUtil.Send2Server(mac);
            return mac;
        }
        public static string randomMac(String source = null)
        {
            string result = "";
            if (source != null)
            {
                if (source.Length > 6)
                {
                    result = source.Substring(0, 6);
                }
            }
            else
            {
                string[] farr = {
                    "002272","00D0EF","086195","F4BD9E","5885E9","BC2392","405582","A4E31B","D89790","883A30","002206","002202","002227","0021ED","0021EB","002260",
                    "001437","001431","00147C","001481","ACED5C","34F64B","9061AE","00E18C","E442A6","00DBDF","98541B","84EF18","A098ED","001925","F0421C","3876CA",
                    "B8BBAF","60C5AD","30E37A","0000C9","0040AA","D0B0CD","7050AF","F4EF9E","84683E","E4B318"
                };
                source = farr[new Random().Next(farr.Length - 1)];
            }
            for (int i = 1; i <= 12; i++)
            {

                if (i < result.Length + 1)
                {
                    continue;
                }

                if (i % 2 == 0)
                {
                    if (i == 2)
                    {
                        result += randomStr(1, new string[] { "0", "2", "4", "6", "8", "A", "C", "E" });
                    }
                    else if (i == 12)
                    {
                        result += randomStr(1, new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E" });
                    }
                    else
                    {
                        result += randomStr(1);
                    }
                }
                else
                {
                    result += randomStr(1);
                }

            }
            result = result.ToUpper();
            return result;
        }
        public static string randomStr(int len, string[] arr = null)
        {
            if (arr == null || arr.Length <= 1)
            {
                arr = new string[16]
                {
                    "a", "b", "c", "d", "e", "f", "0", "1", "2", "3",
                    "4", "5", "6", "7", "8", "9"
                };
            }
            string text = "";
            for (int i = 0; i < len; i++)
            {
                text += arr[new Random(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100)).Next(arr.Length - 1)];
            }
            return text;
        }
    }
}
