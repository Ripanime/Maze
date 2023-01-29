namespace Value 
{
    internal interface IValue
    {
        bool CanBuy(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue);
        bool CanSell(int val, int numberOfValue, int minNumberOfValue, int maxNumberOfValue);
        int Buy(int val, int numberOfValie, int minNumberOfValue, int maxNumberOfValue);
        int Sell(int val, int numberOfvalue, int minNumberOfValue, int maxNumberOfValue);
    }
}
