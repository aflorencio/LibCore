using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCore
{
    public interface IContacto
    {
        IFlow IFlow { get; set; }
        ITicket ITicket { get; set; }

        /// <summary>
        /// Crea un nuevo Rastreo, solo el rastreo sin los enlaces.
        /// </summary>
        /// <remarks>
        /// - Al crear un contacto nuevo se insertara en el FlowService. (RabbitMQ)
        ///  -Al crear lo inserto en ticketService. (RabbitMQ)
        /// </remarks>
        void CreateContacto(MContacto data);
        /// <summary>
        /// Modifica contacto CRUD
        /// </summary>
        void UpdateContacto(string idContacto, string name, string valor);
        /// <summary>
        /// Lee todos los contactos de la base de datos CRUD
        /// </summary>
        Task<List<MContacto>> ReadAllContacto();
        /// <summary>
        /// Muestra la informacion de un contacto CRUD
        /// </summary>
        Task<MContacto> ReadOneContacto(string idContacto);
        /// <summary>
        /// Borra o hace invisible un contacto.
        /// </summary>
        Task DeleteContacto(string idContacto);
        /// <summary>
        /// Retorna el estado de la toma de contacto.
        /// </summary>
        Task<bool> TomaDeContacto(string idContacto);
        /// <summary>
        /// Modifica el estado de la toma de contacto TRUE o FALSE
        /// </summary>
        void TomaDeContacto(bool edit, string id);
        /// <summary>
        /// Mostrará solo los contactos de un trabajador
        /// </summary>
        void ReadEmployeeContacto();
    }
}