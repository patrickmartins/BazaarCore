namespace PM.BazaarCore.Domain.Core.Values
{
    public class Error
    {
        public string Description { get; private set; }
        public string Source { get; private set; }

        public Error(string description, string source)
        {
            Description = description;
            Source = source;
        }
    }
}
