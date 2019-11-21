using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCore
{
    public interface IRastreo
    {
        /// <summary>
        /// Mostrará TRUE o FALSE dependiendo si tiene la solicitud de rastreo o no.
        /// </summary>
        /// <remarks>Esto sera muy util y tiene que estar agregado en la base de datos como "solicitud de rastreo" del tipo bool para determinar en el caso de que un rastreo esté cerrado y se vuelva abrir si tiene que notificar solo al comercial o al comercial y al rastreador de que se ha vuelto abrir el rastreo.</remarks>
        bool solicitudRastreo { get; set; }
        IFlow IFlow { get; set; }
        ITicket ITicket { get; set; }
        IQueueNotification IQueueNotification { get; set; }

        /// <summary>
        /// Crea un nuevo Rastreo, solo el rastreo sin los enlaces.
        /// </summary>
        /// <remarks>
        /// - Al crear un rastreo nuevo se insertara en el FlowService. (RabbitMQ)
        ///  -Al crear lo inserto en ticketService. (RabbitMQ)
        /// - Al crear un nuevo Rastreo notificar en la QueueNotificationService
        /// - Si creas un rastreo y en éste está marcado la solicitud de rastreo este lo enviara a QueueNotificationService. Si no esta marcado como solicitud de rastreo entonces no notificará.
        /// </remarks>
        Task CreateRastreo(Mrastreo data);
        Task<List<Mrastreo>> ReadAllRastreo();
        Task<Mrastreo> ReadOneRastreo(string id);
        void UpdateRastreo(string idContacto, string name, string valor);
        /// <summary>
        /// Delete no borrará solo ocultara un campo de visible si o no
        /// </summary>
        Task DeleteRastreo(string id);
        /// <summary>
        /// Return bool si el rastreo se ha terminado o no.
        /// </summary>
        void RastreoFinalizado();
        /// <summary>
        /// Modifica el estado del rastreo
        /// </summary>
        /// <remarks>
        /// - En el caso que esté finalizado TRUE y se vuelva a poner como abierto FALSE por ejemplo cuando se añada otro enlace; abierto es FALSO. Se mandara a flow como "Se ha vuelto abrir rastreo" y se notificará de nuevo a QueueNotification. En el caso de que se solicitara a los rastreadores lo notificaria.
        /// - Comprobaremos en que si ha existido una notificacion de rastreo anteriormente. Si ha existido una notificacion. Volveremos a rastrear si no. solo lo enviará a comercial. TODO ESO O añadir un campo que sea solicitud de rastreo TRUE FALSE
        /// </remarks>
        void RastreoFinalizado(bool edit);

        /// <summary>
        /// Inserta un link en el sistema de la DB
        /// </summary>
        /// <remarks>
        /// - Si se añade un link al rastreo este pondra de nuevo el modelo como no finalizado. Pondra el estado como FLASE el finalizado como FALSE lo comprobará si está en TRUE lo pone como false llamando a RastreoFinalizado(false). Este enviara de nuevo un flow y una notificacion (esto en el metodo de rastreoFinalizado).
        /// -Si el estado está ya cerrado inserta un enlace con normalidad y no hace nada mas.
        /// </remarks>
        Task CreateLinkRastreo(Link data, string id);
    }
}