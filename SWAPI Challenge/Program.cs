namespace SwapiChallenge {
    using System;
    using System.Threading.Tasks;

    using SwapiUtility;

    public static class Program {
        private static ICharactersUtility CharactersUtility => new CharactersUtility();

        private static IFilmsUtility FilmsUtility => new FilmsUtility();

        private static string FilmTitle { get; set; }
        private static string CharacterName { get; set; }

        public static async Task<string> RunAsync(string filmTitle, string characterName) {
            var characters = await CharactersUtility.GetCharacters(filmTitle).ConfigureAwait(false);
            var films = await FilmsUtility.GetFilms(characterName).ConfigureAwait(false);
            return $"{FilmTitle}: {characters}; {CharacterName}: {films}";
        }

        private static async Task Main() {
            FilmTitle = "A New Hope";
            CharacterName = "Luke Skywalker";
            var message = await RunAsync(FilmTitle, CharacterName).ConfigureAwait(false);
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}