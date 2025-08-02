using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Text.Json; // Use System.Text.Json for serialization/deserialization
using MouseSyncProject.Shared;

namespace MouseSyncProject.Receiver
{
    partial class ReceiverProgram
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public void RunReceiver()
        {
            var listener = new UdpClient(9000);
            var ep = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                var data = listener.Receive(ref ep);
                using var ms = new MemoryStream(data);
                var evt = JsonSerializer.Deserialize<MouseEvent>(ms); // Replace BinaryFormatter with JsonSerializer

                if (evt != null)
                {
                    SetCursorPos(evt.X, evt.Y);
                }
            }
        }
    }
}


