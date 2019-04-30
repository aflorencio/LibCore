using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public interface IContactos : IFlow, ITicket
    {
        /// <summary>
        /// Crea un nuevo Rastreo, solo el rastreo sin los enlaces.
        /// </summary>
        /// <remarks>
        /// - Al crear un contacto nuevo se insertara en el FlowService. (RabbitMQ)
        ///  -Al crear lo inserto en ticketService. (RabbitMQ)
        /// </remarks>
        void CreateContacto();
        /// <summary>
        /// Modifica contacto CRUD
        /// </summary>
        void UpdateContacto();
        /// <summary>
        /// Lee todos los contactos de la base de datos CRUD
        /// </summary>
        void ReadAllContacto();
        /// <summary>
        /// Muestra la informacion de un contacto CRUD
        /// </summary>
        void ReadOneContacto();
        /// <summary>
        /// Borra o hace invisible un contacto.
        /// </summary>
        void DeleteContacto();
        /// <summary>
        /// Return si un contacto a tenido una toma de contacto. TRUE o FALSE
        /// </summary>
        bool TomaDeContacto();
        /// <summary>
        /// Modifica el estado de la toma de contacto TRUE o FALSE
        /// </summary>
        bool TomaDeContacto(bool edit);
        void ReadEmployeeContacto();
    }
}