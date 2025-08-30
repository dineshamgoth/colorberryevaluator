using Microsoft.EntityFrameworkCore;
using BerryTestProject1.Models; // We need this to access the models

namespace BerryTestProject1.Data // Corrected namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Corrected DbSet properties based on our defined models
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<ResultCategory> ResultCategory { get; set; }
        public DbSet<Statement> Statement { get; set; }
        public DbSet<Score> Score { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Your seeding data for ResultCategory and Statement is correct.
            // No changes are needed there.

            // --- Seed ResultCategory Table ---
            modelBuilder.Entity<ResultCategory>().HasData(
                new ResultCategory { ResultCategoryId = 1, CirclePlacement = "The Core", ColorCode = "blue", Message = "Dear {user}, {name} is your heart and soul—an extraordinary, supportive companion. Never, ever leave or hurt {pronoun}." },
                new ResultCategory { ResultCategoryId = 2, CirclePlacement = "The Inner Circle", ColorCode = "teal", Message = "{user}, {name} is your loyal friend—an honest companion with whom your secrets are safe. {pronoun} is your true partner in crime." },
                new ResultCategory { ResultCategoryId = 3, CirclePlacement = "The Allies", ColorCode = "white", Message = "{name} is your supportive friend—a loyal and trusted companion. You may have temporary ego clashes, but the relationship is sustained with support and trust in the long run." },
                new ResultCategory { ResultCategoryId = 4, CirclePlacement = "The Outer Circle", ColorCode = "green", Message = "{name} is neither your trusted friend nor your enemy. The communication is situation-based, not exclusive." },
                new ResultCategory { ResultCategoryId = 5, CirclePlacement = "The Quarantine Zone", ColorCode = "yellow", Message = "You should probably limit your interaction with {name}. {pronoun} will drain your emotions for their own benefit." },
                new ResultCategory { ResultCategoryId = 6, CirclePlacement = "The Exclusion Zone", ColorCode = "red", Message = "Dear {user}, you are in a toxic relationship. Back away from {name} immediately to protect your mental peace." }
            );

            // --- Seed Statement Table ---
            modelBuilder.Entity<Statement>().HasData(
                // Positive Statements
                new Statement { StatementId = 1, AssertiveStatement = "{name} loves you unconditionally, enhances your mood, and makes you smile.", Category = "WellWisher", Score = 5 },
                new Statement { StatementId = 2, AssertiveStatement = "{name} encourages you to go beyond your limits and challenges you to grow.", Category = "GrowthCatalyst", Score = 4 },
                new Statement { StatementId = 3, AssertiveStatement = "You feel safe and comfortable sharing your worst secrets with {name}.", Category = "Protector", Score = 4 },
                new Statement { StatementId = 4, AssertiveStatement = "{name} will stand by you in tough times and encourages you to try new things.", Category = "Supporter", Score = 4 },
                new Statement { StatementId = 5, AssertiveStatement = "{name} calms your heart and mind, bringing you back to your senses when you are a mess.", Category = "Stabilizer", Score = 3 },
                new Statement { StatementId = 6, AssertiveStatement = "You automatically smile when you see {name}, and you share many happy memories together.", Category = "JoyBringer", Score = 3 },
                // Negative Statements
                new Statement { StatementId = 7, AssertiveStatement = "The dislike from {name} feels irrational and baseless, more like a reflection of their own issues.", Category = "Hater", Score = -5 },
                new Statement { StatementId = 8, AssertiveStatement = "{name} has betrayed your trust or made you feel unimportant in your absence.", Category = "Backstabber", Score = -5 },
                new Statement { StatementId = 9, AssertiveStatement = "{name} twists facts to gain an emotional advantage over you.", Category = "Manipulator", Score = -4 },
                new Statement { StatementId = 10, AssertiveStatement = "{name} subtly chips away at your confidence with passive-aggressive remarks.", Category = "Underminer", Score = -4 },
                new Statement { StatementId = 11, AssertiveStatement = "You sense a lack of genuine joy from {name} when you share good news.", Category = "Envyer", Score = -3 },
                new Statement { StatementId = 12, AssertiveStatement = "{name} often exaggerates insignificant emotions to seek attention.", Category = "DramaGenerator", Score = -3 },
                new Statement { StatementId = 13, AssertiveStatement = "When you share a dream or goal, {name} encourages you to play small or stay safe.", Category = "Stagnator", Score = -3 },
                new Statement { StatementId = 14, AssertiveStatement = "{name} frequently uses your resources (time, money, energy) for their own benefit without gratitude.", Category = "Leecher", Score = -2 },
                new Statement { StatementId = 15, AssertiveStatement = "{name} seems to feed on your emotional insecurities, providing no real benefit to you.", Category = "EmotionalVulture", Score = -2 }
            );
        }
    }
}