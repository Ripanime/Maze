using System;
using ValueBase;
namespace BonusBase
{
    public class BonusInteractor : IBonusInteractor
    {
        readonly int price;
        readonly Value value;

        public bool isInteractorFail { get; private set; }

        public event Action<int> OnValueChange = delegate { };
        public event Action<int> OnRemainignUseChange = delegate { };
        public BonusInteractor(int price, int minRemValue, int maxRemValue)
        {
            this.price = price;
            value = new Value(minRemValue, maxRemValue);
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
            OnRemainignUseChange?.Invoke(newRemUse);

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

            OnRemainignUseChange?.Invoke(newRemUse);

            return newRemUse;
        }
        private bool CanBuyBonus(int remUse, int remValue)
        {
            if (remUse < 0)
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
            if (remUse <= 0)
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