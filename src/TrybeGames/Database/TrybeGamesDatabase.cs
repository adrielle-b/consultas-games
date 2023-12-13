namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
       return Games.Where(game => game.DeveloperStudio == gameStudio.Id).ToList();
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        return Games.Where(game => player.GamesOwned.Contains(game.Id)).ToList(); 
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        return Games.Where(game => playerEntry.GamesOwned.Contains(game.Id)).ToList();
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        return Games.Select(game => new GameWithStudio
        {
            GameName = game.Name, 
            StudioName = GameStudios.Find(studio => studio.Id == game.DeveloperStudio)?.Name,
            NumberOfPlayers = game.Players.Count
        }).ToList();
    } 
    
    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        return Games.Select(game => game.GameType).Distinct().ToList();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        return GameStudios.Select(studio => new StudioGamesPlayers
        {
            GameStudioName = studio.Name,
            Games = Games.Where(game => game.DeveloperStudio == studio.Id).Select(game => new GamePlayer
            {
                GameName = game.Name,
                Players = Players.Where(player => player.GamesOwned.Contains(game.Id)).ToList()
            }).ToList()
        }).ToList();
    }

}
