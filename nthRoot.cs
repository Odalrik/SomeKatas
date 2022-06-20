// .NET 6
class Program
{
    static void Main()
    {
        double number = 41.0;
        int n = 7;

        double nthRoot = GetNthRoot(number, n);

        Console.WriteLine($"The {n}th root of {number} = {nthRoot}");
    }


    public static double GetNthRoot(double number, int n)
    {
        if(number == 1.0 || n == 1)
        {
            return number;
        }

        bool computing = true;
        double x = number;

        while(computing)
        {
            // Newton's method
            double f = Fx(number, x, n);
            double fd = Fdx(x, n);

            computing = f > 0;

            if(computing)
            {
                x -= f / fd;
            }
        }

        return x;
    }

    private static double Pow(double number, int pow)
    {
        double result = number;
        for(int i = 1; i < pow; i++)
        {
            result *= number;
        }

        return result;
    }

    private static double Fx(double target, double x, int n)
    {
        return Pow(x, n) - target;
    }

    private static double Fdx(double x, int n)
    {
        return n * Pow(x, n - 1);
    }
}