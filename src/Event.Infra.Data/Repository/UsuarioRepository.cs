using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Repository;

namespace Event.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {


        public Usuario ObterUsuarioPeloId(Guid id)
        {
            return _context.Set<Usuario>().Select(x => x).FirstOrDefault(x => x.Id == id);
        }

    }
}
