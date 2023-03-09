using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool isTimerStopped;
    [SerializeField] private float timeLeft;
    [SerializeField] private bool isTimerOn = false;

    [SerializeField] private GameManager manager;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        isTimerOn = true;
        isTimerStopped = false;
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        if (isTimerOn && !isTimerStopped) 
        {
            if(timeLeft > 0) 
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else 
            {
                manager.OnGameLose();
                timeLeft = 0;
                isTimerOn = false;
            }
        }
    }
    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void AddTime(float increaseTime) 
    {
        if(!isTimerOn && increaseTime < 0) 
        {
            return;
        }
        timeLeft += increaseTime;
    }
}
