
namespace Schlagenfun.Services.Teams.Infrastructure
{
    public class TeamsSeeder
    {
        private TeamsContext _db;
        public TeamsSeeder(TeamsContext teamsDB)
        {
            _db = teamsDB;
            _db.Database.EnsureCreated();            
        }

        public void SeedForDev()
        {
            this.ClearTeams();
            this.SeedTeams();
        }

        private void ClearTeams()
        {
            foreach (var team in _db.Teams)            
                _db.Teams.Remove(team);
            
            _db.SaveChanges();
        }

        private void SeedTeams()
        {
            IList<Team> initialTeams = new List<Team>() {
                                new Team() { Id = 1, Name = "Indians" },
                                new Team() { Id = 2, Name = "Rays" },
                                new Team() { Id = 3, Name = "Phillies" },
                                new Team() { Id = 4, Name = "Marlins" },
                                new Team() { Id = 5, Name = "Braves" }
                            };
            _db.AddRange(initialTeams);
            _db.SaveChanges();            
        }
    }

}