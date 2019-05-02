using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public interface ITicket
    {
        IQueueNotification IQueueNotification { get; set; }

        void CreateTicket();
        void CreateTicketComentario();
        /// <summary>
        /// Alomejor ni se puede modificar.
        /// </summary>
        void UpdateTicket();
        /// <summary>
        /// Lee todos los ticket de un rol. Por ejemplo todos los tickets del tipo "rastreo"
        /// </summary>
        void ReadAllTicketByRol();
        void ReadOneTicket();
        void ReadAllTicket();
        /// <summary>
        /// Lo dejará invisible o incluso no se podrá eliminarlo
        /// </summary>
        void DeleteTicket();
        /// <summary>
        /// Pensar esto: En una sola consulta mostrar todos los ticket de un Flow
        /// </summary>
        void ReadTicketByFlow();
    }
}