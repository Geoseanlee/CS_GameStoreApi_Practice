using GameStore.Api.Dtos;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new(
        1,
        "FIFA 23",
        "Sports",
        100.99M,
        "2021-01-01"),
    new(2, "Call of Duty: Modern Warfare II", "Shooter", 12.33M, "2009-07-05"),
    new(3, "Grand Theft Auto V", "Action", 50.50M, "2013-09-17"),
    new(4, "The Witcher 3: Wild Hunt", "RPG", 28.53M, "2015-05-19"),

];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) =>
{
    GameDto? game = games.Find(game => game.Id == id);
    
    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

// PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if (index < 0)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );

    return Results.NoContent();
});


// DELETE /games/{id}
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});


app.MapGet("/", () => "Hello World!");

app.Run();
