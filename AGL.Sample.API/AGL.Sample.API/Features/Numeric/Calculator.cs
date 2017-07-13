namespace AGL.Sample.API.Features.Numeric
{
    public class Calculator : ICalculator
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}