using System.Diagnostics;

// .NET 6
class Program
{
    static void Main()
    {
        ProduceSomeStrings(out string string1, out string string2, out string string3, out long loops);

        bool test = (string1.GetHashCode() == string2.GetHashCode())
            && !string1.Equals(string2)
            && (string2.GetHashCode() == string3.GetHashCode())
            && !string2.Equals(string3)
            && !string3.Equals(string1);

        Console.WriteLine(
            $"string '{string1}', " +
            $"string '{string2}' and " +
            $"string '{string3}' " +
            $"have same hashcodes ({string1.GetHashCode()}) but different values: {test}");
    }

    private static Random rand = new Random();

    /// <summary>
    /// Produce strings string1 string2 and string3 with same hashcode but different value 
    /// </summary>
    /// <param name="string1"></param>
    /// <param name="string2"></param>
    /// <param name="string3"></param>
    private static void ProduceSomeStrings(out string string1, out string string2, out string string3, out long loops)
    {
        Dictionary<int, string[]> hashCodeAndStrings = new Dictionary<int, string[]>();
        string1 = string.Empty;
        string2 = string.Empty;
        string3 = string.Empty;
        loops = 0;

        bool stop = false;

        while (stop == false)
        {
            string newString = GenerateRandomString();
            int hashCodeOfNewString = newString.GetHashCode();

            if (hashCodeAndStrings.TryGetValue(hashCodeOfNewString, out string[] values))
            {
                if (string.IsNullOrEmpty(values[1]) && (values[0].Equals(newString) == false))
                {
                    values[1] = newString;
                }
                else if ((values[0].Equals(newString) == false) && (values[1].Equals(newString) == false))
                {
                    string1 = values[0];
                    string2 = values[1];
                    string3 = newString;
                    stop = true;
                }
            }
            else
            {
                hashCodeAndStrings.Add(hashCodeOfNewString, new string[2] { newString, string.Empty });

            }

            loops++;
        }
    }

    private static string GenerateRandomString()
    {
        long randomLong = rand.NextInt64();
        return randomLong.ToString();
    }
}