using System;
using ValueBase;
namespace BonusBase
{
    public class BonusInteractor : IBonusInteractor
    {
        readonly int price;
        readonly int maximumRemUse;
        readonly int minimumRemUse;
        readonly Value value;
        readonly BonusType type;

        public bool isInteractorFail { get; private set; }

        public event Action<int> OnValueChange = delegate { };
        public event Action<BonusType,int> OnRemainignUseChange = delegate { };
        public BonusInteractor(int price, int minRemValue, int maxRemValue, BonusType type, int minimumRemUse, int maximumRemUse)
        {
            this.price = price;
            value = new Value(minRemValue, maxRemValue);
            this.type = type;
            this.minimumRemUse = minimumRemUse;
            this.maximumRemUse = maximumRemUse;
        }
        public int AddRemainingUse(int remUse, int plusRemUse, int remValue)
        {
            if (!CanBuyBonus(remUse, remValue))
            {
                isInteractorFail = true;
                return remUse;
            }
            isInteractorFail = false;

            int valuePrediction = BuyBonus(remValue);
            int newRemUse = remValue + plusRemUse;

            OnValueChange?.Invoke(valuePrediction);
            OnRemainignUseChange?.Invoke(type,newRemUse);

            return newRemUse;
        }
        public int RemoveRemainingUse(int remUse, int minusRemUse)
        {
            if (!CanUseBonus(remUse))
            {
                isInteractorFail = true;
                return remUse;
            }
            isInteractorFail = false;

            int newRemUse = remUse - minusRemUse;
            OnRemainignUseChange?.Invoke(type,newRemUse);

            return newRemUse;
        }
        private bool CanBuyBonus(int remUse, int remValue)
        {
            if (remUse <= minimumRemUse || remUse >= maximumRemUse)
            {
                return false;
            }

            if (!value.CanSell(price, remValue))
            {
                return false;
            }
            return true;
        }
        private bool CanUseBonus(int remUse)
        {
            if (remUse <= minimumRemUse)
            {
                return false;
            }
            return true;
        }
        private int BuyBonus(int remValue)
        {
            return value.Sell(price, remValue);
        }
    }
}