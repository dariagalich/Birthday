using ConsoleApp2;
namespace Birthday
{
    public class BirthdayService
    {
        private readonly BirthdayRepository _repository;
        public BirthdayService()
        {
            _repository = new BirthdayRepository();
        }
        public void AddNewBirth()
        {
            Console.Write("Введите ФИО: ");
            string? fio = Console.ReadLine();
            Console.Write("Введите дату рождения (образец гггг.мм.дд): ");
            string? dob = Console.ReadLine();
            User x = new User { Name = fio, Birthday = Convert.ToDateTime(dob) };
            _repository.AddNewBirth(x);
            Console.WriteLine("Объекты успешно сохранены");
        }
        public void DelBirth()
        {
            Console.Write("Введите номер для удаления: ");
            string? id = Console.ReadLine();
            _repository.DelBirth(Convert.ToInt32(id));
            ShowAllBirthList();
        }
        public void ShowAllBirthList()
        {
            Console.WriteLine("\nПолный список дней рождения:");
            var users = _repository.GetAll();
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Birthday.ToString("dd/MM/yyyy")}");
            }
        }
        public void UpcomingBirth()
        {
            var users = _repository.UpcomingBirth();
            if (users != null)
            {
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Birthday}");
                }
            }
        }
        public void ReName()
        {
            Console.Write("Введите номер для редактирования: ");
            string? id = Console.ReadLine();
            var user = _repository.GetById(Convert.ToInt32(id));
            Console.Write("Введите правильное имя: ");
            string correctName = Console.ReadLine();
            user.Name = correctName;
            _repository.Update(user);
        }
        public void ReDate()
        {
            Console.Write("Введите номер для редактирования: ");
            string? id = Console.ReadLine();
            var user = _repository.GetById(Convert.ToInt32(id));
            Console.Write("Введите правильную дату: ");
            string? correctDate = Console.ReadLine();
            user.Birthday = Convert.ToDateTime(correctDate);
            _repository.Update(user);
        }
    }
}
    
