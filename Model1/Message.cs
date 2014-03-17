using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message
    {
        private const int ttl = 40;
        public enum TYPE { QUESTION, ANSWER, ADRESS }
        public int TTL {get; private set;}
        public string RecipientName { get; private set; }//получатель
        public string SenderName { get; private set; }//отправитель
        public TYPE Type { get; private set; }

        public int SenderAdress { get; set; }// в случае ADRESS принимает значение получателя, от сервера DHCP

        public Message(string r, string s, TYPE t)
        {
            TTL = ttl;
            RecipientName = r;
            SenderName = s;
            Type = t;
        }

        public Message(string r, string s, TYPE t, int adress)
        {
            TTL = ttl;
            RecipientName = r;
            SenderName = s;
            Type = t;
            SenderAdress = adress;
        }

        public int dec()
        {
            TTL--;
            return TTL;
        }
    }
}
