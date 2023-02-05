namespace BonusBase
{
    public abstract class BonusInteractor
    {
        public abstract int AddRemainingUse(int remUse);
        public abstract int RemoveRemainingUse();
        public abstract bool CanBuy(int remUse);

    }
    public abstract class BonusLogic
    {
        public abstract void Abuility();
    }
}