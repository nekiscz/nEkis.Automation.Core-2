using System.Linq;

namespace nEkis.Automation.Core.Utilities
{
    /// <summary>
    /// Generates random 'Lorem ipsum' text
    /// </summary>
    public class Lorem
    {
        private const string LOREM = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean faucibus aliquet dolor. Vivamus condimentum hendrerit ligula non tempus. Duis in risus eu arcu viverra tempor non vitae mauris. Aenean congue accumsan augue, ac suscipit nisl tempor ac. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus massa nisl, finibus quis interdum eu, mollis pretium lacus. Nunc facilisis odio et nulla feugiat euismod. Etiam tempor varius neque, sed elementum lacus varius vitae. Donec ultrices nunc enim, eu venenatis nunc vehicula non. Nulla facilisi. Vivamus scelerisque libero est, venenatis bibendum nulla volutpat sed. Nullam pellentesque odio mauris, eget eleifend dui congue at. Nulla aliquet metus eget nisi scelerisque vehicula. Cras tempor tempus est et vestibulum";

        /// <summary>
        /// Whole string of lorem ipsum
        /// </summary>
        public string Ipsum { get { return LOREM; } }

        /// <summary>
        /// Gets one word from Lorem ipsum
        /// </summary>
        /// <returns>Random word from Lorem ipsum</returns>
        public static string Word()
        {
            string[] words = LOREM.Replace(".", "").Replace(",", "").Split(' ');
            return words[SafeRandom.Next(0, words.Length)];
        }

        /// <summary>
        /// Gets one word from Lorem ipsum with given length
        /// </summary>
        /// <param name="length">Length of the word</param>
        /// <returns>Random word from Lorem ipsum</returns>
        public static string Word(int length)
        {
            string[] words = LOREM.Replace(".", "").Replace(",", "").Split(' ').Where(r => r.Length >= length).ToArray();
            return words[SafeRandom.Next(0, words.Length)];
        }

        /// <summary>
        /// Gets one random sentence from Lorem ipsum
        /// </summary>
        /// <returns>Random sentence</returns>
        public static string Sentence()
        {
            string[] sentence = LOREM.Replace(". ", ".").Split('.');
            return sentence[SafeRandom.Next(0, sentence.Length)];
        }

        /// <summary>
        /// Gets number of sentences from lorem ipsum 
        /// </summary>
        /// <param name="sentences">Number of sentences in paragraph</param>
        /// <returns>Random paragraph</returns>
        public static string Paragraph(int sentences)
        {
            string[] sentence = LOREM.Replace(". ", ".").Split('.');
            string paragraph = string.Empty;

            for (int i = 0; i < sentences; i++)
            {
                paragraph += sentence[SafeRandom.Next(0, sentence.Length)] + ". ";
            }

            return paragraph;
        }
    }
}
