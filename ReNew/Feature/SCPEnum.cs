using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNew.Feature
{
    public enum SCPEnum
    {
        SCP049,
        SCP0492,
        SCP079,
        SCP096,
        SCP106,
        SCP173,
        SCP939,
        SCP3114
    }
    public class SCPandRoleConverter
    {
        private Dictionary<SCPEnum, RoleTypeId> convert = new Dictionary<SCPEnum, RoleTypeId>();
        private Dictionary<RoleTypeId, SCPEnum> reverseConvert = new Dictionary<RoleTypeId, SCPEnum>();

        public SCPandRoleConverter()
        {
            convert.Add(SCPEnum.SCP049, RoleTypeId.Scp049);
            convert.Add(SCPEnum.SCP0492, RoleTypeId.Scp0492);
            convert.Add(SCPEnum.SCP079, RoleTypeId.Scp079);
            convert.Add(SCPEnum.SCP096, RoleTypeId.Scp096);
            convert.Add(SCPEnum.SCP106, RoleTypeId.Scp106);
            convert.Add(SCPEnum.SCP173, RoleTypeId.Scp173);
            convert.Add(SCPEnum.SCP939, RoleTypeId.Scp939);
            convert.Add(SCPEnum.SCP3114, RoleTypeId.Scp3114);

            // 역변환 Dictionary 구성
            foreach (var pair in convert)
            {
                reverseConvert[pair.Value] = pair.Key;
            }
        }

        public RoleTypeId ConvR(SCPEnum scp)
        {
            if (!convert.TryGetValue(scp, out var value))
            {
                value = RoleTypeId.Spectator;
            }
            return value;
        }

        public SCPEnum ConvS(RoleTypeId role)
        {
            if (!reverseConvert.TryGetValue(role, out var value))
            {
                value = SCPEnum.SCP079; // 혹은 다른 기본값 지정
            }
            return value;
        }
    }
}
