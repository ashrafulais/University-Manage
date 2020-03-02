using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManage.Data
{
    public interface IGenericRepository<T> where T: class
    {
        List<T> GetAllData();
        T GetById(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);

    }
}
