using Odoo.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Odoo.Repositories
{
    public class RepositoryFactory
    {
        IEnumerable<IRepository> _repos;
        public RepositoryFactory(IEnumerable<IRepository> repos)
        {
            this._repos = repos;
        }

        public IRepository GetRepo(string repoKey)
        {
            IRepository repo = this._repos.Where(obj => obj.GetType().Name == repoKey).FirstOrDefault();
            return repo;
        }
    }
}
