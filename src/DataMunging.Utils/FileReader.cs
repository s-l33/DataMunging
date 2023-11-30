namespace DataMunging.Utils;

public static class FileReader
{
    public static List<FileData> ParseWeatherData(string filePath)
    {
        List<FileData> fileDatas = new();
        string[] lines = ReadFile(filePath);

        for (int i = 1; i < lines.Length; i++)
        {
            var delimiters = new char[] { '\t', (char)32 };
            var data = lines[i].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length > 6)
            {
                var parseResult = ParseToNumber(data[1].Replace("*", string.Empty), data[2].Replace("*", string.Empty));
                if (!parseResult.Item1)
                {
                    continue;
                }

                FileData fileData = new()
                {
                    Name = data[0],
                    ForOrMax = parseResult.Item2,
                    AgainstOrMin = parseResult.Item3,
                };

                fileDatas.Add(fileData);
            }
        }

        return fileDatas;
    }

    public static List<FileData> ParseFootballData(string filePath)
    {
        List<FileData> fileDatas = new();
        string[] lines = ReadFile(filePath);

        for (int i = 1; i < lines.Length; i++)
        {
            var delimiters = new char[] { '\t', (char)32 };
            var data = lines[i].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length > 6)
            {
                var parseResult = ParseToNumber(data[6], data[8]);
                if (!parseResult.Item1)
                {
                    continue;
                }

                FileData fileData = new()
                {
                    Name = data[1],
                    ForOrMax = parseResult.Item2,
                    AgainstOrMin = parseResult.Item3,
                };

                fileDatas.Add(fileData);
            }
        }

        return fileDatas;
    }

    private static string[] ReadFile(string filePath)
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        string fullPath = Path.Combine(Directory.GetParent(projectDirectory).FullName, "Files", filePath);
        string[] lines = File.ReadAllLines(fullPath);
        return lines;
    }

    private static (bool, int, int) ParseToNumber(string forOrMax, string againstOrMin)
    {
        bool canParseForOrMax = int.TryParse(forOrMax, out int _forOrMax);
        bool canParseAgainstOrMin = int.TryParse(againstOrMin, out int _againstOrMin);
        return (canParseForOrMax && canParseAgainstOrMin, _forOrMax, _againstOrMin);
    }
}