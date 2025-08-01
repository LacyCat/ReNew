using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Request : ICommand
    {
        public string Command => "request";

        public string[] Aliases => new string[] { "ㄱㄷㅂ", "req", "요청" };

        public string Description => "아이디어 요청";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Error(Player.Get(sender).Nickname + " 님이 " + arguments.Array[arguments.Offset] + " 아이디어를 제시했습니다");
            response = arguments.Array[arguments.Offset] + " 아이디어가 전송되었습니다!";
            return true;
        }
    }
}
