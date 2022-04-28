using System.Text.RegularExpressions;

namespace Zadanie1.DemoTarget
{
    public static class ToDo
    {
        // Spłaszczenie kolekcji w obiekcie upraszcza jego strukturę.
        // Może to być przydatne przy eksportowaniu do hurtowni danych używanej do raportowania, statystyk i innych analiz.
        // Konsekwencją takiego rozwiązania będzie powielenie ilości elementów nowej tablicy.
        // Zwiększy to zużycie pamięci.
        public static IEnumerable<PersonWithEmail>
            Flatten(IEnumerable<DemoSource.Person> people)
        {
            foreach (var person in people)
            {
                foreach (var email in person.Emails)
                {
                    yield return new PersonWithEmail()
                    {
                        SanitizedNameWithId =
                            $"{Regex.Replace(person.Name, "[^a-zA-Z]", string.Empty)}{Regex.Replace(person.Id, @"[^\d]", "")}",
                        FormattedEmail =
                            $"{email.Email}{email.EmailType}"
                    };
                }
            }
        }
    }
}
