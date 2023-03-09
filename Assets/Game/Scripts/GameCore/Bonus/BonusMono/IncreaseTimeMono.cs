using UnityEngine;
using BonusBase;

public class IncreaseTimeMono : MonoBehaviour
{
    [SerializeField] private BonusPriceData priceData;
    [SerializeField] private BonusRemainingUseData remainingUseData;
    [SerializeField] private GoldData goldData;
    [SerializeField] private BonusIncreaseTimeData timeData;
    [SerializeField] private Timer timer;
    [SerializeField] private int minusRemainingUse;
    [SerializeField] private int plusRemainingUse;

    private int previousRemUse;
    private BonusInteractor interactor;
    private void Awake()
    {
        interactor = new BonusInteractor(priceData.IncreaseTime,goldData.MinNumberOfValue,goldData.MaxNumberOfValue,BonusType.IncreaseTime,timeData.MinRemainingUse,timeData.MaxRemainingUse);

        interactor.OnValueChange += EventManager.SendGoldChanged;
        interactor.OnRemainignUseChange += EventManager.SendRemainingUseChange;
    }
    public void BonusUsed() 
    {
        previousRemUse = interactor.RemoveRemainingUse(remainingUseData.IncreaseTimeRemUse, minusRemainingUse);
        if (!interactor.isInteractorFail)
        {
            remainingUseData.IncreaseTimeRemUse = previousRemUse;
            timer.AddTime(timeData.IncreaseTime);
        }
    }
    public void BonusBuy()
    {
        previousRemUse = interactor.AddRemainingUse(remainingUseData.IncreaseTimeRemUse, plusRemainingUse, goldData.NumberOfValue);
        if (!interactor.isInteractorFail)
        {
            remainingUseData.IncreaseTimeRemUse = previousRemUse;
        }
    }
}
