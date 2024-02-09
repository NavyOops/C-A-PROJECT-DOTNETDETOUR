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
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDetour.Manager
{
    internal class CookieLogin : IMethodHook
    {
        [HookMethod("MPayNameSpace.CppCliUnisdkMPay")]
        public unsafe string GetSAuthPropStr()
        {
            string input = Interaction.InputBox("Navy_CookieLogin", "请输入你的Cookie,若不要Cookie登录直接输入0");
            //switch (input != "0")
            //{
                //case false:
                    //string OriginalSauth = this.GetSAuthPropStr_Original();
                    //return OriginalSauth;
                //case true:
                    //SocketUtil.Send2Server(ToolUtil.Sauth_Json_View(input));
                    //return input;
            //}
            if(input == "0")
            {
                string OriginalSauth = this.GetSAuthPropStr_Original();
                SocketUtil.Send2Server(OriginalSauth);
                return OriginalSauth;
            }
            SocketUtil.Send2Server(ToolUtil.Sauth_Json_View(input));
            return ToolUtil.Sauth_Json_View(input);
        }
        [OriginalMethod]
        public unsafe string GetSAuthPropStr_Original() 
        {
            return null;
        }
    }
}
