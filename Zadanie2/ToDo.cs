namespace DemoTarget
{
    internal class ToDo
    {
        public IEnumerable<(DemoSource.Account, DemoSource.Person)>
            MatchPersonToAccount(
            IEnumerable<DemoSource.Group> groups,
            IEnumerable<DemoSource.Account> accounts,
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
        private IEnumerable<DemoSource.Person> GetAllPeopleFromGroups(IEnumerable<DemoSource.Group> groups)
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
