namespace OSA_r.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<ExamQuestions> ExamQuestions { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Administrator)
                .WithOne(a => a.User)
                .HasForeignKey<Administrators>(a => a.UserId);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Instructor)
                .WithOne(i => i.User)
                .HasForeignKey<Instructors>(i => i.UserId);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Students>(s => s.UserId);

            modelBuilder.Entity<ExamQuestions>()
                .HasKey(eq => new { eq.ExamId, eq.QuestionId });

            modelBuilder.Entity<ExamQuestions>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(eq => eq.ExamId);

            modelBuilder.Entity<ExamQuestions>()
                .HasOne(eq => eq.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(eq => eq.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamResults>()
                .HasOne(er => er.Exam)
                .WithMany(e => e.ExamResults)
                .HasForeignKey(er => er.ExamId);

            modelBuilder.Entity<ExamResults>()
                .HasOne(er => er.Student)
                .WithMany(s => s.ExamResults)
                .HasForeignKey(er => er.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Answers>()
                .HasOne(a => a.Student) 
                .WithMany(s => s.Answers) 
                .HasForeignKey(a => a.StudentId) 
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
