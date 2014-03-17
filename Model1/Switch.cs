using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Switch : Device
    {
        
        public Switch(string name)
        {
            this.name = name;
            ports = new Port[4];
            for (int i = 0; i < 4; i++)
            {
                ports[i] = new Port(this);
            }
            for (int i = 0; i < 10; i++)
            {
                lastMessages.Add(new Message("null", "null", Message.TYPE.ANSWER));
            }
        }

        public override void ImportMessage(Message message)//переписать!!!
        {
            ExportMessage(message);
            //if (DeviceState == DeviceStateFlags.ON)
            //{
            //    message.dec();
            //    if (message.TTL > 0)
            //        foreach (var m in ports)
            //        {
            //            if (m.device != null)
            //            m.device.ImportMessage(message);
            //        }
            //}
        }
    }
}
