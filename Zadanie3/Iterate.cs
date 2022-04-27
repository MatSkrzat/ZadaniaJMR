namespace Zadanie3
{
    public static class Iterate
    {
        public static IEnumerable<IEnumerable<string>>
            OnlyBigCollections(List<IEnumerable<string>> toFilter)
        {
            Func<IEnumerable<string>, bool> predicate =
                list => list.ElementAtOrDefault(5) != default;
            return toFilter.Where(predicate);
        }
    }
}
