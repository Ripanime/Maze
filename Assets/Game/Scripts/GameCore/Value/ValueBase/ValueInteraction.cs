using System;

namespace ValueBase
{
    public enum InteractionType 
    {
        Add,
        Remove
    }
    public class ValueInteraction
    {
        public bool isInteractionFalse { get; private set; }
        readonly InteractionType interactionType;
        private Value value;
        public ValueInteraction(InteractionType interactionType,int minNumberOfValue,int maxNumberOfValue) 
        {
            this.interactionType = interactionType;
            value = new Value(minNumberOfValue,maxNumberOfValue);
        }
        public int Interaction(int val, int numberOfValue)
        {
            switch (interactionType)
            {
                case InteractionType.Add:
                    if (value.CanBuy(val, numberOfValue))
                    {
                        val = value.Buy(val, numberOfValue);
                        isInteractionFalse = false;
                        return val;
                    }
                    break;
                case InteractionType.Remove:
                    if (value.CanSell(val, numberOfValue))
                    {
                        val = value.Sell(val, numberOfValue);
                        isInteractionFalse = false;
                        return val;
                    }
                    break;
            }
            isInteractionFalse = true;
            return val;
        }
    }
}
