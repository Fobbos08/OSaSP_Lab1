using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace net
{
    class Program
    {
        static void Main(string[] args)
        {
            Device d = new Switch("Swithc 1");
            d.On();
            Device d2 = new Switch("Switch 2");
            d2.On();
            d2.ConnectPort(d);
            Device dhcp = new DHCPServer();
            dhcp.On();
            dhcp.ConnectPort(d2);
            Computer c1 = new Computer("Computer 1");
            c1.On();
            c1.ConnectPort(d);
            c1.GetMyAdress();
            Computer c2 = new Computer("Computer 2");
            c2.On();
            c2.ConnectPort(d2);
            c2.GetMyAdress();
            Message m = new Message("Computer 2", c1.Name, Message.TYPE.QUESTION, c1.Adress);
            c1.ExportMessage(m);
        }
    }
}
