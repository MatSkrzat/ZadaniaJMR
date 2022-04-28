using Zadanie2.DemoSource;

namespace Zadanie2.DemoTarget
{
    public class ToDo
    {
        public IEnumerable<(Account, Person)>
            MatchPersonToAccount(
            IEnumerable<Group> groups,
            IEnumerable<Account> accounts,
            IEnumerable<string> emails)
        {
            foreach (var person in GetAllPeopleFromGroups(groups))
            {
                foreach (var email in person.Emails)
                {
                    yield return (accounts.FirstOrDefault(
                        account => account.EmailAddress.Email == emails.FirstOrDefault(
                            e => e.Equals(email)
                            )
                        ), person);
                }
            }
        }
        private IEnumerable<Person> GetAllPeopleFromGroups(IEnumerable<Group> groups)
        {
            foreach (var group in groups)
            {
                foreach (var person in group.People)
                {
                    yield return person;
                }
            }
        }
    }
}
