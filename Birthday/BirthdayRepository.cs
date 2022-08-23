using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Birthday
{
    public class BirthdayRepository
    {
        private readonly ApplicationContext _db;


        public BirthdayRepository()
        {
            _db = new ApplicationContext();
        }
        public void AddNewBirth(User user) //добавление записи в БД
        {
            // добавляем их в бд
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id"></param>
        public void DelBirth(int id) //удаление записи из БД
        {
            User? user = _db.Users.FirstOrDefault(x => x.Id == id);


            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }
        /// <summary>
        /// Возвращает всех пользователей
        /// </summary>
        /// <returns> Все пользователи </returns>
        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }
        /// <summary>
        /// Вывод ближайших ДР
        /// </summary>
        /// <returns>Список ближайших ДР</returns>
        public List<User> UpcomingBirth()
        {
             return _db.Users.Where(x => x.Birthday.DayOfYear > DateTime.Now.DayOfYear && x.Birthday.DayOfYear < DateTime.Now.DayOfYear + 15).ToList();
        }
        public void Update (User user)
        {
            if (user != null)
            {

                _db.Users.Update(user);
                _db.SaveChanges();
            }
        }
        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
