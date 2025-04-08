using System;

class Program
{
    const double EPS = 1e-12;
    const double PI = Math.PI;

    static double GetShift(double a, double H, double h)
    {
        return (H / 2.0) * Math.Sin(a) - h * Math.Tan(a);
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int h = int.Parse(input[0]);
        int H = int.Parse(input[1]);
        int L = int.Parse(input[2]);

        double maxAngle = Math.Acos((double)h / H);

        double left = 0.0, right = maxAngle;
        double bestShift = 0;

        while (right - left > EPS)
        {
            double m1 = left + (right - left) / 3.0;
            double m2 = right - (right - left) / 3.0;

            double s1 = GetShift(m1, H, h);
            double s2 = GetShift(m2, H, h);

            if (s1 < s2)
                left = m1;
            else
                right = m2;
        }

        double finalShift = GetShift((left + right) / 2.0, H, h);

        if (finalShift < -L)
            finalShift = -L;

        Console.WriteLine(finalShift.ToString("F6"));
    }
}

