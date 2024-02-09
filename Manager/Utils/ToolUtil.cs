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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDetour.Manager.Utils
{
    internal class ToolUtil
    {
        public static string Sauth_Json_View(string Sauth_Json)
        {
            //Parse Sauth_Json Data
            JObject keyValuePairs = JObject.Parse(Sauth_Json);
            //Get Data
            if (keyValuePairs["sauth_json"].ToString() == null)
            {
                //Normal X19 Sauth_Json
                return Sauth_Json;
            }
            else
            {
                //X19 Login-Otp Data
                return keyValuePairs["sauth_json"].ToString();
            }
        }
    }
}
