using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using MouseSyncProject.Shared;

namespace MouseSyncProject.Sender
{    
    public partial class SenderProgram
    {
        public void RunSender()
        {
            var client = new UdpClient();
            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.5.5"), 9000);

            while (true)
            {
                var pos = System.Windows.Forms.Cursor.Position;
                var evt = new MouseEvent { X = pos.X, Y = pos.Y };

                var json = JsonSerializer.Serialize(evt);
                var data = Encoding.UTF8.GetBytes(json);

                // Send the serialized data
                client.Send(data, data.Length, remoteEndPoint);

                Thread.Sleep(10);
            }
        }
    }
}



