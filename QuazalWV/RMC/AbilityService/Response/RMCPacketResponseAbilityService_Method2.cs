﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseAbilityService_Method2 : RMCPResponse
    {

        public List<GR5_PersonaAbilityUpgrade> list = new List<GR5_PersonaAbilityUpgrade>();

        public RMCPacketResponseAbilityService_Method2()
        {
            GR5_PersonaAbilityUpgrade p = new GR5_PersonaAbilityUpgrade();
            p.slots.Add(new GR5_AbilityUpgradeSlot());
            list.Add(p);
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)list.Count);
            foreach (GR5_PersonaAbilityUpgrade p in list)
                p.toBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[RMCPacketResponseAbilityService_Method2]";
        }

        public override string PayloadToString()
        {
            return "";
        }
    }
}
