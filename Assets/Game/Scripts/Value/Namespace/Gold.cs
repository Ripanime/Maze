namespace Value 
{
    public class Gold : IValue
    {
        private int predictionNumber;
        public bool CanBuy(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue)
        {
            predictionNumber = 0;
            predictionNumber = numberOfValue + val;
            if (predictionNumber >= minNumberOfValue && predictionNumber <= maxNumberOfValue)
            {
                return true;
            }
            return false;
        }
        public int Buy(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue)
        {
            if (CanBuy(val, numberOfValue, minNumberOfValue, maxNumberOfValue))
            {
                return numberOfValue += val;
            }
            return -1;
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
        public int Sell(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue)
        {
            if (CanSell(val, numberOfValue, minNumberOfValue, maxNumberOfValue))
            {
                return numberOfValue -= val;
            }
            return -1;
        }
    }
}
