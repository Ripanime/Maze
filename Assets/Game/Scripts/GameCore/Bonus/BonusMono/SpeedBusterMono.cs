using UnityEngine;
using BonusBase;

public class SpeedBusterMono : MonoBehaviour
{
    [SerializeField] private BonusPriceData priceData;
    [SerializeField] private GoldData goldData;
    [SerializeField] private PlayerControllerData playerData;
    [SerializeField] private SpeedBusterBonusData speedBusterData;
    [SerializeField] private BonusRemainingUseData remainingUseData;
    [SerializeField] private int minusRemainingUse;
    [SerializeField] private int plusRemainingUse;

    private float previousMoveSpeed;
    private int previousRemUse;
    private BonusInteractor bonusInteractor;
    private SpeedBusterLogic busterLogic;
    private void Awake()
    {
        previousMoveSpeed = playerData.MoveSpeed;

        bonusInteractor = new BonusInteractor(priceData.SpeedBuster, goldData.MinNumberOfValue, goldData.MaxNumberOfValue, BonusType.SpeedBuster, speedBusterData.MinRemainingUse, speedBusterData.MaxRemainingUse);
        busterLogic = new SpeedBusterLogic(speedBusterData.DurationTime,speedBusterData.Multiplier);

        busterLogic.OnBonusUsed += BonusStart;
        busterLogic.OnBonusStopped += BonusStopped;

        bonusInteractor.OnValueChange += EventManager.SendGoldChanged;
        bonusInteractor.OnRemainignUseChange += EventManager.SendRemainingUseChange;
    }
    public void BonusUsed() 
    {
        previousRemUse = bonusInteractor.RemoveRemainingUse(remainingUseData.SpeedBusterRemUse, minusRemainingUse);
        if (!bonusInteractor.isInteractorFail) 
        {
            remainingUseData.SpeedBusterRemUse = previousRemUse;
            StartCoroutine(busterLogic.BonusPlayingTime());
        }
    }
    public void BonusBuy() 
    {
        previousRemUse = bonusInteractor.AddRemainingUse(remainingUseData.SpeedBusterRemUse, plusRemainingUse, goldData.NumberOfValue);
        if (!bonusInteractor.isInteractorFail) 
        {
            remainingUseData.SpeedBusterRemUse = previousRemUse;
        }
    }
    private void BonusStart()
    {
        playerData.MoveSpeed = busterLogic.ChangeMoveSpeed(playerData.MoveSpeed);
    }
    private void BonusStopped()
    {
        playerData.MoveSpeed = previousMoveSpeed;
    }
}
