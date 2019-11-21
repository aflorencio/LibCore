using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCore
{
    public class Link
    {
        public string _id { get; set; }
        public string impacto { get; set; }
        public string comentario { get; set; }
        public string categoria { get; set; }
        public string idioma { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string originalPDF { get; set; }
        public string finalPDF { get; set; }
    }

    public class Mrastreo
    {
        //public string _id { get; set; }
        public List<string> idContactoService { get; set; }
        public bool finalizado { get; set; }
        public string idTicketService { get; set; }
        public string keyWord { get; set; }
        public List<Link> links { get; set; }
    }

}
