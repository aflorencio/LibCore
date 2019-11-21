using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Start _ = new Start("");
            //Link data = new Link();

            //data.url = "http://hola.es";
            //_.Rastreo.CreateLinkRastreo(data, "5ce284a2bf18b807acb326d5");

            MContacto data = new MContacto();

            data.nombre = "SOYALVARO";

            _.Contacto.CreateContacto(data);
        }
    }
}
