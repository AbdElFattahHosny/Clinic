using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repo.GenericInterFace
{
    public interface IGenericInterface<T> where T : class
    {

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(long id);

        void Add(T t);

        void Edit(long oldId, T t);

        void Delete(T t);

    }
}
