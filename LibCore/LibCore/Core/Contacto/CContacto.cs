using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tiny.RestClient;

namespace LibCore
{
    public class CContacto : IContacto
    {
        public IFlow IFlow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITicket ITicket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MLoadBalancer LoadBalancer;

        public CContacto(MLoadBalancer balancer) {
            LoadBalancer = balancer;
        }

        public void CreateContacto(string nombre, string apellidos, string dni, string cif, string direccion, string localidad, string provincia, string cp, string pais, string telefono1, string telefono2, string email1, string email2, string langNative, string particularEmpresa, string descripcionCaso, string fuenteCliente)
        {
            #region CREATE USUARIO
            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            //var response = client.PostRequest("contacto").

            //    AddFormParameter("nombre", nombre == "" ? null : nombre).
            //    AddFormParameter("apellidos", apellidos == "" ? null : apellidos).
            //    AddFormParameter("dni", dni == "" ? null : dni).
            //    AddFormParameter("cif", cif == "" ? null : cif).
            //    AddFormParameter("direccion", direccion == "" ? null : direccion).
            //    AddFormParameter("municipio", localidad == "" ? null : localidad).
            //    AddFormParameter("provincia", provincia == "" ? null : provincia).
            //    AddFormParameter("codPostal", cp == "" ? null : cp).
            //    AddFormParameter("pais", pais == "" ? null : pais).

            //    AddFormParameter("telefono1", telefono1 == "" ? null : telefono1).
            //    AddFormParameter("telefono2", telefono2 == "" ? null : telefono2).
            //    AddFormParameter("email1", email1 == "" ? null : email1).
            //    AddFormParameter("email2", email2 == "" ? null : email2).

            //    AddFormParameter("langNative", langNative == "" ? null : langNative).
            //    AddFormParameter("particularEmpresa", particularEmpresa == "" ? null : particularEmpresa).
            //    AddFormParameter("descripcionCaso", descripcionCaso == "" ? null : descripcionCaso).
            //    AddFormParameter("fuentePosibleCliente", fuenteCliente == "" ? null : fuenteCliente).
            //    ExecuteAsync<bool>();

            MContacto data = new MContacto();
            data.nombre = nombre == "" ? null : nombre;
            data.apellidos = apellidos == "" ? null : apellidos;
            data.dni = dni == "" ? null : dni;
            data.cif = cif == "" ? null : cif;
            data.direccion = direccion == "" ? null : direccion;
            data.municipio = localidad == "" ? null : localidad;
            data.provincia = provincia == "" ? null : provincia;
            data.codPostal = cp == "" ? null : provincia;
            data.pais = pais == "" ? null : pais;
            data.telefono1 = telefono1 == "" ? null : telefono1;
            data.telefono2 = telefono2 == "" ? null : telefono2;
            data.email1 = email1 == "" ? null : email1;
            data.email2 = email2 == "" ? null : email2;
            data.langNative = langNative == "" ? null : langNative;
            data.particularEmpresa = particularEmpresa == "" ? null : particularEmpresa;
            data.desCasoCliente = descripcionCaso == "" ? null : descripcionCaso;

            var response2 = client.PostRequest("contacto/add", data).ExecuteAsync<bool>();
            #endregion

            #region CREATE FLOW
            //LLAMO AL SERVICIO FLOW Y CREO UN FLOW AL CONTACTO CON LOS STATUS EN FALSE
            var idContacto = "5c9ba0766aa59e1350466315";
            var clienteFlow = new TinyRestClient(new HttpClient(), LoadBalancer.FlowService.server.url);
            var resClienteFlow = clienteFlow.PostRequest("flow/" + idContacto).ExecuteAsync<bool>();
            #endregion

            #region CREATE TIMELINE
            //CREO UN TIMELINE AL FLOW DEL TIPO CONTACTO CREADO 
            // var createTimeline = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var timeLineRest = clienteFlow.PostRequest("addToFlow/" + idContacto).
                AddFormParameter("fecha", "20190423000000").
                AddFormParameter("tipo", "Registro").
                AddFormParameter("idTipo", idContacto).
                AddFormParameter("titulo", "Contacto creado").
                AddFormParameter("mensaje", "El contacto ha sido creado").
                AddFormParameter("ticket", "00015458").
                AddFormParameter("visto", "false").
                AddFormParameter("terminado", "false").
                ExecuteAsync<bool>();
            #endregion

        }

        public async Task DeleteContacto(string idContacto)
        {

            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var contacto = await client.DeleteRequest("contacto" + "/delete?id=" + idContacto).ExecuteAsync<MContacto>();

        }

        public async Task<List<MContacto>> ReadAllContacto()
        {
            #region READ ALL CONTACTO
            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var contacto = await client.GetRequest("contacto/all").ExecuteAsync<List<MContacto>>();
            #endregion

            return contacto;
            //throw new System.NotImplementedException();
        }

        public async Task<MContacto> ReadOneContacto(string idContacto)
        {
            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var contacto = await client.GetRequest("contacto" + "/one?id=" + idContacto).ExecuteAsync<MContacto>();

            return contacto;
            //throw new System.NotImplementedException();
        }

        public void UpdateContacto(string idContacto, string name, string valor)
        {
            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var contacto = client.PutRequest("contacto" + "/update?id=" + idContacto + "&name=" + name + "&value=" + valor).ExecuteAsync<MContacto>();

        }
        // ES necesario? hace lo mismo que leer un contacto por id
        public void TomaDeContacto()
        {
            throw new System.NotImplementedException();
        }
        // Es necesario? hace lo mismo que editar contacto
        public void TomaDeContacto(bool edit, string id)
        {
            throw new System.NotImplementedException();
        }

        public void ReadEmployeeContacto()
        {
            throw new System.NotImplementedException();
        }

    }
}