using UnityEngine;
using BonusBase;
using UnityEditor;
using UnityEngine.Events;

public class SpeedBusterMono : MonoBehaviour
{
    [SerializeField] private BonusPriceData priceData;
    [SerializeField] private GoldData goldData;
    [SerializeField] private PlayerControllerData playerData;
    [SerializeField] private SpeedBusterBonusData speedBusterData;
    [SerializeField] private int minusRemainingUse;
    [SerializeField] private int plusRemainingUse;  

    private float previousMoveSpeed;
    private int previousRemUse;
    private BonusInteractor bonusInteractor;
    private SpeedBusterLogic busterLogic;
    private void Awake()
    {
        previousMoveSpeed = playerData.MoveSpeed;

        bonusInteractor = new BonusInteractor(priceData.SpeedBuster, goldData.MinNumberOfValue, goldData.MaxNumberOfValue);
        busterLogic = new SpeedBusterLogic(speedBusterData.DurationTime,speedBusterData.Multiplier);

        busterLogic.OnBonusUsed += BonusStart;
        busterLogic.OnBonusStopped += BonusStopped;

        bonusInteractor.OnValueChange += EventManager.SendGoldChanged;
        bonusInteractor.OnRemainignUseChange += EventManager.SendRemainingBonusChange;
    }
    public void BonusUsed() 
    {
        previousMoveSpeed = bonusInteractor.RemoveRemainingUse(speedBusterData.RemainingUse, minusRemainingUse);
        if (!bonusInteractor.isInteractorFail) 
        {
            speedBusterData.RemainingUse = previousRemUse;
            busterLogic.BonusPlayingTime();
        }
    }
    public void BonusBuy() 
    {
        previousRemUse = bonusInteractor.AddRemainingUse(speedBusterData.RemainingUse, plusRemainingUse, goldData.NumberOfValue);
        if (!bonusInteractor.isInteractorFail) 
        {
            speedBusterData.RemainingUse = previousRemUse;
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
