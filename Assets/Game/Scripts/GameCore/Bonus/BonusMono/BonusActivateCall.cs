using System.Collections;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class BonusActivateCall : MonoBehaviour
{
    public static bool isActive { get; private set; }
    [SerializeField] private TextMeshProUGUI bonusDelayText;
    [SerializeField] private OpenButton button;
    [SerializeField] private float bonusDelay;
    [SerializeField] private float timerWaitTime;

    [SerializeField] private UnityEvent onBonusActivated;
    [SerializeField] private UnityEvent onBonusDeactivated;

    private float timer = 0f;
    public void Call() 
    {
        StartCoroutine(nameof(ActivateBonus));
    }
    private IEnumerator ActivateBonus()
    {
        timer = 0f;
        onBonusActivated.Invoke();
        isActive = true;
        StartCoroutine(nameof(Timer));

        yield return new WaitForSeconds(bonusDelay);

        onBonusDeactivated.Invoke();
        isActive = false;
    }
    private IEnumerator Timer()
    {
        while(timer <= bonusDelay)
        {
            if (button.isClosed) 
            {
                bonusDelayText.text = String.Empty;
            }
            else 
            {
                bonusDelayText.text = Math.Round(bonusDelay - timer, 1).ToString();
            }
            yield return new WaitForSeconds(timerWaitTime);
            timer += timerWaitTime;
        }
    }
}
