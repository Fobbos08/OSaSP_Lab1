using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DHCPServer : Device
    {
        public DHCPServer()
        {
            ports = new Port[1];
            for (int i = 0; i < 1; i++)
            {
                ports[i] = new Port(this);
            }
            this.name = "Server";
            Adress = 1;
        }
        int counter = 1;
        public override void ImportMessage(Message message)
        {
            if (DeviceState == DeviceStateFlags.ON)//!!!!!!
            if (message.RecipientName == this.name && message.Type == Message.TYPE.ADRESS)
            {
                counter++;
                System.Console.WriteLine("Сервер: Отправляю адрес");
                Message m = new Message(message.SenderName, message.RecipientName, Message.TYPE.ADRESS, counter);
                ExportMessage(m);
            }
        }
    }
}
