using UnityEngine;
using UnityEngine.Events;
using TMPro;
/// <summary>
/// Contains "withChecks" variations
/// </summary>
public enum GameType2
{
    withChecks,
    withoutAnything
};
public class LevelFinish : MonoBehaviour
{
    [SerializeField] private GameType2 gameType;
    [SerializeField] private GameManager manager;
    [SerializeField] private TextEnable textEnable;
    [SerializeField] private CheckTrecker checkTrecker;

    [SerializeField] private UnityEvent OnAllCheckPressed;

    private int allChecks;
    private int chechsChecked;

    private Check[] checks;
    private void Start()
    {
        checks = GetComponentsInChildren<Check>();
        allChecks = checks.Length;
    }
    private void Update()
    {
        switch (gameType) 
        {
            case GameType2.withChecks:
                if (manager.GetStoppedGame())
                {
                    return;
                }
                if(checkTrecker.Checked == false) 
                {
                    return;
                }
                Debug.Log(checkTrecker.Checked);
                chechsChecked++;

                if (chechsChecked != allChecks)
                {
                    EventManager.SendCheckPressed(allChecks - chechsChecked);
                    textEnable.EnableText();
                }
                else
                {
                    OnAllCheckPressed.Invoke();
                }

                checkTrecker.Checked = false;

            break;
        }
    }
    public bool IsCompleted() 
    {
        switch (gameType) 
        {
            case GameType2.withChecks:
                return allChecks - chechsChecked <= 0;
            default:
                return true;
        }
    }
}
