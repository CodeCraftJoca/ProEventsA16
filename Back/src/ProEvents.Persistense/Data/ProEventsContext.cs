using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Models;

namespace ProEvents.Persistense.Data
{
    public class ProEventsContext : DbContext
    {
       
        public ProEventsContext(DbContextOptions<ProEventsContext> options)
        : base(options){}

        public DbSet<Event> Events {get; set;}
        public DbSet<Speaker> Speakers {get; set;}
        public DbSet<Batch> Batches {get; set;}
        public DbSet<SpeakerEvent> speakerEvents {get; set;}
        public DbSet<SocialNetwork> SocialNetworks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite Key
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(SE => new { SE.EventId, SE.SpeakerId });


            modelBuilder.Entity<Batch>()
                            .HasOne(b => b.Event)
                            .WithMany(e => e.Batch)
                            .HasForeignKey(b => b.EventId);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialNetwork)
                .WithOne(sn => sn.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
               .HasMany(s => s.SocialNetwork)
               .WithOne(sn => sn.Speaker)
               .OnDelete(DeleteBehavior.Cascade);



        }
    }
}

