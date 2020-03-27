using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dari.Service
{
    public class ServiceAnnonce : Service<Annonce>, IServiceAnnonce
    {
        public ServiceAnnonce(IUnitOfWork uow) : base(uow)
        {

        }

        /*public IEnumerable<Annonce> ListeAnnonce()
        {
            
        }*/
    }
}
