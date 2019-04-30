using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class Main
    {
        public void Hola()
        {
            ITicket _ = new CTicket();
            _.CreateTicketComentario();
            _.CreatePushNotification();
            throw new System.NotImplementedException();
        }
    }
}