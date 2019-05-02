using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class Start
    {
        //public CoreLib.Core.lib.IContactoComercial Contacto;
        public IContacto Contacto;

        public Start(string token)
        {
            // 1. Ira al load balancer y sacara los servidores activos
            // 2. Comprobará la autorizacion para usar la API
            // 3. Que usuario está detras de la peticion y rol
            // 4. devuelve la peticion.


            MLoadBalancer checkServer = new QLoadBalancer().GetBalancerInfo();



            Contacto = new CContacto(checkServer);

        }

    }
}
