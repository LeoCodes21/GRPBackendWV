﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class Payload_SessionInfos : DupObjPayload
    {
        public override byte[] toBuffer()
        {
            MemoryStream m = new MemoryStream();
            m.WriteByte(1); // BasicUpdateProtocol<SES_SessionHeartbeat>
            Helper.WriteU32(m, 0);
            m.WriteByte(1); // BasicUpdateProtocol<SES_SessionInfosParameter>
            Helper.WriteU32(m, 0);
            m.Write(new byte[256], 0, 256);
            return m.ToArray();
        }

        public override string getDesc(string tabs = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(tabs);
            byte[] buff = toBuffer();
            foreach (byte b in buff)
                sb.Append(b.ToString("X2") + " ");
            return sb.ToString();
        }
    }
}