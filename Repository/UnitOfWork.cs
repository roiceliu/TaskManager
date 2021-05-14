using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace Repository
{
    public class UnitOfWork
    {
        //one copy of context used by all repository -- Singleton
        private TaskManagerEntities context = new TaskManagerEntities();
        private IGenericRepo<tblQuote> quoteRepo;

        //initiate the variables in the class
        public IGenericRepo<tblQuote> QuoteRepo
        {
            get
            {

                if (this.quoteRepo == null)
                {
                    this.quoteRepo = new GenericRepo<tblQuote>(context);
                }
                return quoteRepo;
            }
        }


    }
}
