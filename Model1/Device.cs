using System;
using System.Collections.Generic;

namespace Model
{

    public abstract class Device : IDevice
    {
        public enum DeviceStateFlags { ON = 1, OFF = 0 }
        private DeviceStateFlags deviceState = new DeviceStateFlags();
        public DeviceStateFlags DeviceState { get { return deviceState; } set { deviceState = value; } }
        private int adress;
        public int Adress { get { return adress; } set { adress = value; } }
        protected string name;
        public string Name { get { return name; } }
        protected Port[] ports;
        public IEnumerable<Port> Ports { get { return ports; } }
        public delegate void MessageEventHandler(Message message);
        public event MessageEventHandler ExportMessageEvent;
        protected List<Message> lastMessages = new List<Message>();

        protected virtual void OnSomeEvent(Message message)
        {
            MessageEventHandler handler = ExportMessageEvent;
            if (ExportMessageEvent != null) handler(message);
        }

        public bool ConnectPort(Device device )
        {
            foreach (var a in ports)
            {
                if (a.State == Port.STATE.DISCONNECT)
                {
                    foreach(var b in device.Ports)
                    {
                        if (b.State == Port.STATE.DISCONNECT)
                        {
                        bool flag = a.Connect(b);
                        if (flag == true) return true;}
                        }  
                }
            }
            return false;
        }

        public void On()
        {
            deviceState = DeviceStateFlags.ON;
        }

        public void Off()
        {
            deviceState = DeviceStateFlags.OFF;
        }
        
        public abstract void ImportMessage(Message message);

        //public void ExportMessage(string r)
        //{
        //    if (deviceState == DeviceStateFlags.ON)
        //    {
        //        System.Console.WriteLine("Узнаю наличие компьютера");
        //        Message message = new Message(r, this.name, Message.TYPE.QUESTION, this.Adress);
        //        message.dec();
        //        if (message.TTL > 0)
        //            foreach (var m in ports)
        //            {
        //                if (m.device != null)
        //                m.device.ImportMessage(message);
        //            }
        //    }
        //}

        //public void ExportMessage(string r, string s, Message.TYPE t)
        //{
        //    if (deviceState == DeviceStateFlags.ON)
        //    {
        //        Message message = new Message(r, s, t, this.Adress);
        //        message.dec();
        //        if (message.TTL > 0)
        //            foreach (var m in ports)
        //            {
        //                if (m.device != null)
        //                m.device.ImportMessage(message);
        //            }
        //    }
        //}

        //public void ExportMessage(string r, string s, Message.TYPE t, int adress)
        //{
        //    if (deviceState == DeviceStateFlags.ON)
        //    {
        //        Message message = new Message(r, s, t, adress);
        //        message.dec();
        //        if (message.TTL > 0)
        //            foreach (var m in ports)
        //            {
        //                if (m.device != null)
        //                m.device.ImportMessage(message);
        //            }
        //    }
        //}

        public void ExportMessage(Message message)
        {
            if (deviceState == DeviceStateFlags.ON)
            {
                foreach (var m in lastMessages)
                {
                    if (message == m) return;
                }
                if (lastMessages.Count != 0)
                {
                    lastMessages.Add(message);
                    lastMessages.RemoveAt(0);
                }
                message.dec();
                if (message.TTL > 0)
                OnSomeEvent(message);
                /*message.dec();
                if (message.TTL > 0)
                    foreach (var m in ports)
                    {
                        if (m.device != null)
                        m.device.ImportMessage(message);
                    }*/
            }
        }
    }
}
