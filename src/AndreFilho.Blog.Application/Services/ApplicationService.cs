using AndreFilho.Blog.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Application.Services
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _uow;

        public ApplicationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
