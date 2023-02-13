using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class BonusCall : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bonusDelayText;
    [SerializeField] private float bonusDelay;
    [SerializeField] private float timerWaitTime;

    [SerializeField] private UnityEvent onBonusActivated;
    [SerializeField] private UnityEvent onBonusDeactivated;
    [SerializeField] private UnityEvent onBonusBuy;

    private float timer = 0f;
    public void BuyBonus() 
    {
        onBonusBuy.Invoke();
    }
    public IEnumerator ActivateBonus()
    {
        timer = 0f;

        onBonusActivated.Invoke();
        StartCoroutine(nameof(Timer));

        yield return new WaitForSeconds(bonusDelay);

        onBonusDeactivated.Invoke();
    }
    private IEnumerator Timer() 
    {
        while(timer <= bonusDelay) 
        {
            bonusDelayText.text = (bonusDelay - timer).ToString();
            yield return new WaitForSeconds(timerWaitTime);
            timer += timerWaitTime;
        }
    }
}
