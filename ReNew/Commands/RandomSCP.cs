using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
using ReNew.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class RandomSCP : ICommand
    {
        public string Command => "change";

        public string[] Aliases => new string[0];

        public string Description => "";

        private static Random rng = new Random();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player senders = Player.Get(sender);
            if (!senders.IsScp)
            {
                response = "당신은 SCP가 아닙니다!";
                return false;
            }
            else
            {
                SCPandRoleConverter converter = new SCPandRoleConverter();
                RoleTypeId roles = converter.ConvR(RandomPick(converter.ConvS(senders.Role)));
                senders.Role.Set(roles);
                response = roles.ToString() + " 으로 변환되었습니다!";
                return true;
            }
        }
        public static SCPEnum RandomPick(SCPEnum lowValue)
        {
            var values = Enum.GetValues(typeof(SCPEnum)).Cast<SCPEnum>().ToList();
            int count = values.Count;
            double baseProb = 1.0 / count;
            double minSub = 0.03;
            double maxSub = baseProb - 0.03;
            if (maxSub <= minSub)
                throw new InvalidOperationException("Too few enum values or baseProb too small for given min/max.");
            double sub = rng.NextDouble() * (maxSub - minSub) + minSub;
            Dictionary<SCPEnum, double> probabilities = new Dictionary<SCPEnum, double>();
            for (int i = 0; i < values.Count; i++)
            {
                SCPEnum val = values[i];
                if (val.Equals(lowValue))
                {
                    probabilities[val] = baseProb - sub;
                }
                else
                {
                    probabilities[val] = baseProb + sub / (count - 1);
                }
            }
            double roll = rng.NextDouble();
            double cumulative = 0.0;
            foreach (KeyValuePair<SCPEnum, double> kvp in probabilities)
            {
                cumulative += kvp.Value;
                if (roll < cumulative)
                    return kvp.Key;
            }
            return values[values.Count - 1];
        }
    }
}
