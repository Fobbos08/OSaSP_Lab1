using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDevice
    {
        void On();
        void Off();
        bool ConnectPort(Device device);
        void ImportMessage(Message message);
        //void ExportMessage(string r);
        void ExportMessage(Message message);
        //void ExportMessage(string r, string s, Message.TYPE t);
        //void ExportMessage(string r, string s, Message.TYPE t, int adress);
    }
}
