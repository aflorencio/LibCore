using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tiny.RestClient;

namespace LibCore
{
    public class CRastreo : IRastreo
    {
        public bool solicitudRastreo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFlow IFlow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITicket ITicket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IQueueNotification IQueueNotification { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MLoadBalancer LoadBalancer;

        public CRastreo(MLoadBalancer balancer)
        {
            LoadBalancer = balancer;
        }

        public async Task CreateLinkRastreo(Link data, string id)
        {

            #region CREATE LINK
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var response2 = await client.PostRequest("rastreo/addLink?id=" + id, data).ExecuteAsync<bool>();
            #endregion

        }

        public async Task CreateRastreo(Mrastreo data)
        {
            #region CREATE RASTREO
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var response2 = await client.PostRequest("rastreo/add", data).ExecuteAsync<bool>();
            #endregion
        }

        public async Task DeleteRastreo(string id)
        {
            #region DELETE RASTREO
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var response2 = await client.DeleteRequest("rastreo/delete?id="+id).ExecuteAsync<bool>();
            #endregion
        }

        public void RastreoFinalizado()
        {
            throw new System.NotImplementedException();
        }

        public void RastreoFinalizado(bool edit)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Mrastreo>> ReadAllRastreo()
        {
            #region READ ALL RASTREO
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var contacto = await client.GetRequest("rastreo/all").ExecuteAsync<List<Mrastreo>>();
            #endregion

            return contacto;

        }

        public async Task<Mrastreo> ReadOneRastreo(string id)
        {
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var rastreo = await client.GetRequest("rastreo" + "/one?id=" + id).ExecuteAsync<Mrastreo>();

            return rastreo;

        }

        public void UpdateRastreo(string idContacto, string name, string valor)
        {
            var client = new TinyRestClient(new HttpClient(), "http://localhost:5002/api");
            var contacto = client.PutRequest("rastreo" + "/update?id=" + idContacto + "&name=" + name + "&value=" + valor).ExecuteAsync<MContacto>();
        }
    }
}