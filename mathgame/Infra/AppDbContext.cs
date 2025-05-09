using mathgame.Entities;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
    public DbSet<AccessCodeEntity> AccessCodes { get; set; }
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<DifficultyEntity> Difficulties { get; set; }
    public DbSet<OperationEntity> Operations { get; set; }
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<ResponseEntity> Responses { get; set; }
    public DbSet<ParticipantEntity> Participants { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}