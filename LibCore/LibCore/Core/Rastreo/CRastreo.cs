using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class CRastreo : IRastreo
    {
        public bool solicitudRastreo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFlow IFlow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITicket ITicket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IQueueNotification IQueueNotification { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CreateLinkRastreo()
        {
            throw new System.NotImplementedException();
        }

        public void CreateRastreo()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRastreo()
        {
            throw new System.NotImplementedException();
        }

        public void RastreoFinalizado()
        {
            throw new System.NotImplementedException();
        }

        public void RastreoFinalizado(bool edit)
        {
            throw new NotImplementedException();
        }

        public void ReadAllRastreo()
        {
            throw new System.NotImplementedException();
        }

        public void ReadOneRastreo()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRastreo()
        {
            throw new NotImplementedException();
        }
    }
}