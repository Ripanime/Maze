namespace ValueBase
{
    public enum InteractionType 
    {
        Add,
        Remove
    }
    public class ValueInteraction
    {
        readonly int maxNumberOfValue;
        readonly int minNumberOfValue;
        readonly InteractionType interactionType;

        private Value value;
        public ValueInteraction(InteractionType interactionType,int maxNumberOfValue,int minNumberOfValue) 
        {
            this.interactionType = interactionType;
            this.maxNumberOfValue = maxNumberOfValue;
            this.minNumberOfValue = minNumberOfValue;
            value = new Value();
        }
        public int Interaction(int val, int numberOfValue)
        {
            switch (interactionType)
            {
                case InteractionType.Add:
                    if (value.CanBuy(val,numberOfValue,minNumberOfValue,maxNumberOfValue))
                    {
                        val = value.Buy(val,numberOfValue);
                        return val;
                    }
                    break;
                case InteractionType.Remove:
                    if (value.CanSell(val,numberOfValue,minNumberOfValue,maxNumberOfValue))
                    {
                        val = value.Sell(val, numberOfValue);
                        return val;
                    }
                    break;
            }
            return int.MinValue;
        }
    }
}
