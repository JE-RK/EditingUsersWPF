using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItemList(); // получение всех объектов
        T GetItem(Guid id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(Guid id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
