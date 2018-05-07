namespace SwapiChallenge {
    using System;
    using System.Threading.Tasks;

    using SwapiUtility;

    public static class Program {
        private static ICharactersUtility CharactersUtility => new CharactersUtility();

        private static IFilmsUtility FilmsUtility => new FilmsUtility();

        private static string FilmTitle { get; set; }
        private static string CharacterName { get; set; }

        private static async Task RunAsync(string filmTitle, string characterName) {
            var characters = await CharactersUtility.GetCharacters(filmTitle).ConfigureAwait(false);
            var films = await FilmsUtility.GetFilms(characterName).ConfigureAwait(false);
            var message = $"{FilmTitle}: {characters}; {CharacterName}: {films}";
            Console.WriteLine(message);
        }

        private static async Task Main() {
            FilmTitle = "A New e";
            CharacterName = "Luke Skyw";
            await RunAsync(FilmTitle, CharacterName).ConfigureAwait(false);
            Console.ReadKey();
        }
    }
}