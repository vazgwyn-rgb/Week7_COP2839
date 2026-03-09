using ClassSchedule.Models;

namespace ClassSchedule.Models.DataLayer
{
    public class ClassScheduleUnitOfWork : IClassScheduleUnitOfWork
    {
        private ClassScheduleContext context { get; }


        private IRepository<Class> classData;
        private IRepository<Teacher> teacherData;
        private IRepository<Day> dayData;


        public ClassScheduleUnitOfWork(ClassScheduleContext ctx)
        {
            context = ctx;

        }
        public IRepository<Class> Classes
        {
            get
            {
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }
        public IRepository<Teacher> Teachers
        {
            get
            {
                if (teacherData == null)
                    teacherData = new Repository<Teacher>(context);
                return teacherData;
            }
        }
        public IRepository<Day> Days
        {
            get
            {
                if (dayData == null)
                    dayData = new Repository<Day>(context);
                return dayData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
