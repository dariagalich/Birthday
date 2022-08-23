using ConsoleApp2;
namespace Birthday
{
    public class BirthdayRepository
    {
        private readonly ApplicationContext _db;
        public BirthdayRepository()
        {
            _db = new ApplicationContext();
        }
        /// <summary>
        /// Добавляет пользователя в БД
        /// </summary>
        /// <param name="user"></param>
        public void AddNewBirth(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        /// <summary>
        /// Удаляет пользователя из БД
        /// </summary>
        /// <param name="id"></param>
        public void DelBirth(int id)
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
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }
        }
        /// <summary>
        /// Вывод ближайших ДР
        /// </summary>
        /// <returns>Список ближайших ДР</returns>
        public List<User> UpcomingBirth()
        {
             return _db.Users.Where(x => x.Birthday.DayOfYear > DateTime.Now.DayOfYear && x.Birthday.DayOfYear < DateTime.Now.DayOfYear + 15).ToList();
        }
        /// <summary>
        /// Обноаляет данные в БД 
        /// </summary>
        /// <param name="user"></param>
        public void Update (User user)
        {
            if (user != null)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }
        }
        /// <summary>
        /// Ищет пользователя по введеному ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Пользователь</returns>
        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
