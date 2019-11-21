using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class MContacto
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string dni { get; set; }
        public string cif { get; set; }
        public string municipio { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string lang { get; set; }
        public string langNative { get; set; }
        public string partnerAsignado { get; set; }
        public string comercialAsignado { get; set; }
        public string particularEmpresa { get; set; }
        public string descripcionCaso { get; set; }
        public bool recibidoPorSecretaria { get; set; }
        public string fuentePosibleCliente { get; set; }
        public string rol { get; set; } = "contacto";
        public bool tomaContacto { get; set; } = false;

    }
}