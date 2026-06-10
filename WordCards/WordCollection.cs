using System.Collections.ObjectModel;
using System.IO;
using WordCards;

namespace WordCards
{
    public class WordCollection : Collection<WordItem>
    {
        public void LoadFromStringArray(string[] lines)
        {
            this.Clear();
            foreach (string line in lines)
            {
                this.Add(new WordItem(line));
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (WordItem item in this)
                {
                    writer.WriteLine(item.ToLineString());
                }
            }
        }
    }
}