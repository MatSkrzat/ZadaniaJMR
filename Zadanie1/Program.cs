using System.Text.RegularExpressions;

// Spłaszczenie kolekcji w obiekcie upraszcza jego strukturę.
// Może to być przydatne przy eksportowaniu do hurtowni danych używanej do raportowania, statystyk i innych analiz.
// Konsekwencją takiego rozwiązania będzie powielenie ilości elementów nowej tablicy.
// Zwiększy to zużycie pamięci.
static IEnumerable<DemoTarget.PersonWithEmail>
    Flatten(IEnumerable<DemoSource.Person> people)
{
    foreach (var person in people)
    {
        foreach (var email in person.Emails)
        {
            yield return new DemoTarget.PersonWithEmail()
            {
                SanitizedNameWithId =
                    $"{Regex.Replace(person.Name, "[^a-zA-Z]", string.Empty)}{Regex.Replace(person.Id, @"[^\d]", "")}",
                FormattedEmail =
                    $"{email.Email}{email.EmailType}"
            };
        }
    }
}

List<DemoSource.Person> mockPeople = new List<DemoSource.Person>()
{
    new DemoSource.Person()
    {
        Id = "1",
        Name = "Adam",
        Emails = new List<DemoSource.EmailAddress>()
        {
            new DemoSource.EmailAddress()
            {
                Email = "adam@one.pl",
                EmailType = "work"
            },
            new DemoSource.EmailAddress()
            {
                Email = "adam@two.pl",
                EmailType = "home"
            },
            new DemoSource.EmailAddress()
            {
                Email = "adam@three.pl",
                EmailType = "work"
            },
        }
    },
    new DemoSource.Person()
    {
        Id = "2a",
        Name = "Tomek2",
        Emails = new List<DemoSource.EmailAddress>()
        {
            new DemoSource.EmailAddress()
            {
                Email = "tomek@one.pl",
                EmailType = "work"
            },
            new DemoSource.EmailAddress()
            {
                Email = "tomek@two.pl",
                EmailType = "home"
            },
            new DemoSource.EmailAddress()
            {
                Email = "tomek@three.pl",
                EmailType = "home"
            },
        }
    },
    new DemoSource.Person()
    {
        Id = "3b",
        Name = "Anna4533",
        Emails = new List<DemoSource.EmailAddress>()
        {
            new DemoSource.EmailAddress()
            {
                Email = "anna@one.pl",
                EmailType = "work"
            },
            new DemoSource.EmailAddress()
            {
                Email = "ania@two.pl",
                EmailType = "home"
            },
            new DemoSource.EmailAddress()
            {
                Email = "anusia@three.pl",
                EmailType = "home"
            },
        }
    },
};

var flattenCollection = Flatten(mockPeople).ToList();
foreach (var item in flattenCollection)
{
    Console.WriteLine(item.SanitizedNameWithId + " " + item.FormattedEmail);
}


