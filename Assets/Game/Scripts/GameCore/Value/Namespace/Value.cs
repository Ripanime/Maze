namespace ValueBase
{
    internal interface IValue 
    {
        int Buy(int val, int numberOfValue);
        int Sell(int val, int numberOfValue);
    }
    public class Value
    {
        private int predictionNumber;
        public bool CanBuy(int val, int numberOfValue, int minNumberOfValue,int maxNumberOfValue)
        {
            predictionNumber = 0;
            predictionNumber = numberOfValue + val;
            if (predictionNumber >= minNumberOfValue && predictionNumber <= maxNumberOfValue)
            {
                return true;
            }
            return false;
        }
        public int Buy(int val,int numberOfValue)
        {
            return numberOfValue += val;
        }
        public bool CanSell(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue)
        {
            predictionNumber = 0;
            predictionNumber = numberOfValue - val;
            if (predictionNumber >= minNumberOfValue && predictionNumber <= maxNumberOfValue)
            {
                return true;
            }
            return false;
        }
        public int Sell(int val, int numberOfValue)
        {
            return numberOfValue -= val;
        }
    }
}
