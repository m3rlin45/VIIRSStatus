using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace RDR
{
    public class RdrStaticHeader
    {
        public string Satellite { get; set; }
        public string Sensor { get; set; }
        public string TypeId { get; set; }
        public UInt32 NumApids { get; set; }
        public UInt32 ApidListOffset { get; set; }
        public UInt32 PktTrackerOffset { get; set; }
        public UInt32 ApStorageOffset { get; set; }
        public UInt32 NextPacketPos { get; set; }
        public Int64 startBoundary { get; set; }
        public Int64 endBoundary { get; set; }

        public RdrStaticHeader() { }
        public RdrStaticHeader(IEnumerable<Byte> byteStream) : this(byteStream.GetEnumerator()) { }
        public RdrStaticHeader(IEnumerator<Byte> enumerator)
        {
            this.Satellite = (new string
                (enumerator.getNextBytes(4).Select(Convert.ToChar).ToArray())).Trim('\0');
            this.Sensor = (new string
                (enumerator.getNextBytes(16).Select(Convert.ToChar).ToArray())).Trim('\0');
            this.TypeId = (new string
                (enumerator.getNextBytes(16).Select(Convert.ToChar).ToArray())).Trim('\0');
            this.NumApids = BitConverter.ToUInt32(enumerator.getNextBytes(4).Reverse().ToArray(), 0);
            this.ApidListOffset = BitConverter.ToUInt32(enumerator.getNextBytes(4).Reverse().ToArray(), 0);
            this.PktTrackerOffset = BitConverter.ToUInt32(enumerator.getNextBytes(4).Reverse().ToArray(), 0);
            this.ApStorageOffset = BitConverter.ToUInt32(enumerator.getNextBytes(4).Reverse().ToArray(), 0);
            this.NextPacketPos = BitConverter.ToUInt32(enumerator.getNextBytes(4).Reverse().ToArray(), 0);
            this.startBoundary = BitConverter.ToInt64(enumerator.getNextBytes(8).Reverse().ToArray(), 0);
            this.endBoundary = BitConverter.ToInt64(enumerator.getNextBytes(8).Reverse().ToArray(), 0);
        }
    }

    static class helper
    {
        static public Byte[] getNextBytes(this IEnumerator<Byte> enumerator, int numBytes)
        {
            Byte[] ret = new Byte[numBytes];
            for (int i = 0; i < numBytes; i++)
            {
                if (!enumerator.MoveNext())
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    ret[i] = enumerator.Current;
                }
            }
            return ret;
        }
    }
}
