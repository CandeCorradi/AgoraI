using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    internal interface IInscripcionService
    {
    }
    public interface IInsripcionService : IGenericService<Inscripcion>
    {
        public Task<List<Inscripcion>?> GetIscriptosAsync(string email);
    }



}
