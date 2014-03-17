using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Port
    {
        public enum STATE{CONNECT, DISCONNECT};
        public STATE State { get; private set; }

        public IDevice device;
        public IDevice MyDevice { get; private set; }

        public Port(IDevice MyDevice)
        {
            this.MyDevice = MyDevice;
            State = STATE.DISCONNECT;
        }

        public bool Connect(Port port)
        {
            if (State == STATE.DISCONNECT)
            {
                device = port.MyDevice;
                (device as Device).ExportMessageEvent += MyDevice.ImportMessage;
                port.device = MyDevice;
                (MyDevice as Device).ExportMessageEvent += port.MyDevice.ImportMessage;
                port.State = STATE.CONNECT;
                State = STATE.CONNECT;

                return true;    
            }
            else 
            {
                return false;
            }
        }

        public bool Disconnect(Port port)
        {
            if (State == STATE.DISCONNECT)
            {
                State = STATE.DISCONNECT;
                return false;
            }
            else
            {
                if (device != port.device)
                {
                    return false;
                }
                else
                {
                    (device as Device).ExportMessageEvent -= MyDevice.ImportMessage;
                    (MyDevice as Device).ExportMessageEvent -= port.MyDevice.ImportMessage;
                    device = null;
                    State = STATE.DISCONNECT;
                    port.State = STATE.DISCONNECT;
                    port.device = null;
                    return true; 
                }
            }
        }
    }
}
