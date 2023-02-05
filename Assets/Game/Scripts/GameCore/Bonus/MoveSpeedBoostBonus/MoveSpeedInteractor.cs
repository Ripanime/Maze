namespace BonusBase
{
    public class MoveSpeedInteractor : BonusInteractor
    {
        public override int AddRemainingUse(int remUse)
        {
            
        }
        public override int RemoveRemainingUse()
        {
            throw new System.NotImplementedException();
        }
        public override bool CanBuy(int remUse)
        {
            return remUse > 0;
        }
    }
}