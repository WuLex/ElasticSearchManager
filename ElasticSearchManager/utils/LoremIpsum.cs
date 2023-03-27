using System.Text;

namespace ElasticSearchManager.utils
{
    public static class LoremIpsum
    {
        private static readonly string[] _words = new[]
        {
        "lore", "itself", "pain", "be", "amet", "consequent", "adipiscing", "elit", 
		"but", "do", "just like that", "time", "happen ", "as", "labor", "and", "pain", "big", "any"
       };

        public static string Paragraphs(int count)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                builder.AppendLine(string.Join(" ", Enumerable.Range(1, random.Next(5, 15))
                    .Select(_ => _words[random.Next(_words.Length)])));
            }
            return builder.ToString();
        }
    }
}