namespace ValueBase
{
    internal interface IValue 
    {
        int Buy(int val, int numberOfValue);
        int Sell(int val, int numberOfValue);
    }
    public class Value
    {
        readonly int minNumberOfValue;
        readonly int maxNumberOfValue;
        private int predictionNumber;
        public Value(int minNumberOfValue,int maxNumberOfValue) 
        {
            this.minNumberOfValue = minNumberOfValue;
            this.maxNumberOfValue = maxNumberOfValue;
        }
        public bool CanBuy(int val, int numberOfValue)
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
        public bool CanSell(int val, int numberOfValue)
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
