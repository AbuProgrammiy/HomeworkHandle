namespace CalculatorTest
{
    public static class CalculatorMethods
    {
        public static double  Plus(double a, double b)
        {
            return a + b;
        }

        public static double Minus(double a, double b)
        {
            return a - b;
        }

        public static double Multiple(double a, double b)
        {
            return a * b;
        }

        public static double Devide(double a, double b)
        {
            if(a==0||b==0)
                throw new DivideByZeroException();
            return a/b;
        }
    }
}
