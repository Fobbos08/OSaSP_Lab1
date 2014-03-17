using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Computer : Device
    {
        public Computer(string name)
        {
            this.name = name;
            ports = new Port[1];
            for (int i = 0; i < 1; i++)
            {
                ports[i] = new Port(this);
            }
            
        }
        public override void ImportMessage(Message message)
        {
            if (DeviceState == Device.DeviceStateFlags.ON)
                if (message.RecipientName == this.name)
            {
                if (message.Type == Message.TYPE.QUESTION)
                {
                    System.Console.WriteLine("Компьтер " + this.name + "отправляю свой адрес");
                    Message m = new Message(message.SenderName, this.name, Message.TYPE.ANSWER);
                    ExportMessage(m);
                }
                if (message.Type == Message.TYPE.ANSWER)
                {
                    System.Console.WriteLine("Компьтер " + this.name + "Доставка гарантированная");
                }
                if (message.Type == Message.TYPE.ADRESS)
                {
                    this.Adress = message.SenderAdress;
                    System.Console.WriteLine("Компьтер " + this.name + "получил адрес");
                }
            }
           
        }

        public void GetMyAdress()
        {
            Message m = new Message("Server", this.name, Message.TYPE.ADRESS);
            ExportMessage(m);

        }
    }
}
