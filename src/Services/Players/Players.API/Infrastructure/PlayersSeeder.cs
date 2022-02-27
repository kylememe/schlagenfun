
namespace Schlagenfun.Services.Players.Infrastructure
{
    public class PlayersSeeder
    {
        private PlayersContext _db;
        public PlayersSeeder(PlayersContext playersDB)
        {
            _db = playersDB;
            _db.Database.EnsureCreated();            
        }

        public void SeedForDev()
        {
            this.ClearPlayers();
            this.SeedPlayers();
        }

        private void ClearPlayers()
        {
            foreach (var player in _db.Players)            
                _db.Players.Remove(player);
            
            _db.SaveChanges();
        }

        private void SeedPlayers()
        {
            IList<Player> initialPlayers = new List<Player>() {
                                new Player() { Id = 1, FirstName = "Knox", LastName = "Smith", Age = 8 },
                                new Player() { Id = 2, FirstName = "Astor", LastName = "Freely", Age= 8 },
                                new Player() { Id = 3, FirstName = "Solomon", LastName = "Man", Age = 7 },
                                new Player() { Id = 4, FirstName = "Landon", LastName = "Stacks", Age = 8 },
                                new Player() { Id = 5, FirstName = "Lucas", LastName = "Morgan", Age = 7 }
                            };
            _db.AddRange(initialPlayers);
            _db.SaveChanges();            
        }
    }

}