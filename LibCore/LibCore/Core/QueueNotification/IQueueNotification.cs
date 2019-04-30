using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public interface IQueueNotification
    {
        /// <summary>
        /// Crea un canal de notificaciones por ejemplo: un usuario uno o un trabajador que se incorpore a la plantialla
        /// </summary>
        void CreateChannelNotification();
        /// <summary>
        /// Inserta una nueva notificacion o añadade a la cola una nueva notificacion
        /// </summary>
        void CreatePushNotification();
        /// <summary>
        /// Modifica una notificacion (no podrá ser usado)
        /// </summary>
        void UpdateNotification();
        /// <summary>
        /// Elimina una publicacion (no podra ser usado)
        /// </summary>
        void DeleteNotification();
        /// <summary>
        /// Añade una prioridad a una notificacion en concreto
        /// </summary>
        void AddPriorityNotification();
        /// <summary>
        /// Modifica el status de la Notificacion. Sera por porcentajes donde 100% será terminado o notificacion vista.
        /// </summary>
        void UpdateStatusNotification();
    }
}