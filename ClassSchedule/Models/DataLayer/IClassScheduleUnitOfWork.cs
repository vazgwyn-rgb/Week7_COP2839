
namespace ClassSchedule.Models.DataLayer
{
    public interface IClassScheduleUnitOfWork
    {
        IRepository<Class> Classes { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Day> Days { get; }
        void Save();
    }
}
