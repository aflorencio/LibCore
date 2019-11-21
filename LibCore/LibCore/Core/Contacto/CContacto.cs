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

        public void CreateContacto(MContacto data)
        {
            #region CREATE USUARIO
            var client = new TinyRestClient(new HttpClient(), "http://127.0.0.1:5001/api/");

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
        public async Task<bool> TomaDeContacto(string idContacto)
        {
            #region READ ALL CONTACTO  Y CON LINQ EXTRAER
            var client = new TinyRestClient(new HttpClient(), LoadBalancer.ContactoService.server.url);
            var contacto = await client.GetRequest("contacto/all").ExecuteAsync<List<MContacto>>();

            var result = from d in contacto
                         where d._id == idContacto
                         select d.tomaContacto;
            #endregion
            var toBool = result.FirstOrDefault();
            return toBool;
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