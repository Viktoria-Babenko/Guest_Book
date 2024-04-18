using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Guest_Book.Models
{
    public class ReviewsContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MessegesModel> Messeges { get; set; }
        public ReviewsContext(DbContextOptions<ReviewsContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                MessegesModel messeges = new MessegesModel();
                messeges.MessegeDate = DateTime.Now;
                messeges.Messeges = "Давно мечтала получить специальность Программирование. И вот я в Компьютерной Академии ШАГ. \r\nПервое впечатление максимально положительное. Удобное расположение в самом центре города, аудитории оснащены современным оборудованием, приветливый персонал, консультации по любым организационным вопросам. Небольшие группы, что позволяет уделить внимание каждому студенту. Дружеская атмосфера способствует хорошим результатам в обучении.";
                UserModel user = new UserModel();
                user.FirstName = "Виктория";
                user.LastName = "Бабенко";
                user.Login = "Babenko";
                user.Password = "52E077AC753A501F753915C4CA53936011698FEDD64A3EA72F6143A91BDB9B34";
                user.Salt = "864787AA832ABD0E114E41B60AB87EA8";
                Users?.Add(user);
                user.Messeges?.Add(messeges);

                MessegesModel messeges1 = new MessegesModel();
                messeges1.MessegeDate = DateTime.Now;
                messeges1.Messeges = "Пришел в IT Академию Шаг в 2017 году, закончил малую академию, после чего записался на курс 'разработка на Python' Очень доволен преподавателем Владимиром Поповым. Человек разбирается во всем, что у него не спроси. По поводу обучения: абсолютно актуальный на сегодняшний день материал. Преподносят информацию превосходно, с большим энтузиазмом. Настоятельно рекомендую!";
                UserModel user1 = new UserModel();
                user1.FirstName = "Иван";
                user1.LastName = "Иваненко";
                user1.Login = "Ivanenko";
                user1.Password = "D5D39C4E195FCA2FFECF2EF78CE9756F6E7E762980395DC57C0BB708F768C4D4";
                user1.Salt = "A5C4336EAED06357D3A172745E3FEB35";
                Users?.Add(user1);
                user1.Messeges?.Add(messeges1);

                SaveChanges();
            }
        }
    }
}
