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
        void CreateContacto(string nombre, string apellidos, string dni, string cif, string direccion, string localidad, string provincia, string cp, string pais, string telefono1, string telefono2, string email1, string email2, string langNative, string particularEmpresa, string descripcionCaso, string fuenteCliente);
        /// <summary>
        /// Modifica contacto CRUD
        /// </summary>
        void UpdateContacto();
        /// <summary>
        /// Lee todos los contactos de la base de datos CRUD
        /// </summary>
        Task<string> ReadAllContacto();
        /// <summary>
        /// Muestra la informacion de un contacto CRUD
        /// </summary>
        void ReadOneContacto();
        /// <summary>
        /// Borra o hace invisible un contacto.
        /// </summary>
        void DeleteContacto();
        /// <summary>
        /// Retorna el estado de la toma de contacto.
        /// </summary>
        void TomaDeContacto();
        /// <summary>
        /// Modifica el estado de la toma de contacto TRUE o FALSE
        /// </summary>
        void TomaDeContacto(bool edit);
        /// <summary>
        /// Mostrará solo los contactos de un trabajador
        /// </summary>
        void ReadEmployeeContacto();
    }
}