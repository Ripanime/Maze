using UnityEngine;
using UnityEngine.Events;
using TMPro;
/// <summary>
/// Contains "withChecks" variations
/// </summary>
public enum PathType
{
    withChecks,
    withoutAnything
};
public class LevelFinish : MonoBehaviour
{
    [SerializeField] private PathType gameType;
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
            case PathType.withChecks:
                if (manager.isStopped)
                {
                    return;
                }
                if(checkTrecker.Checked == false) 
                {
                    return;
                }
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
            case PathType.withChecks:
                return allChecks - chechsChecked <= 0;
            default:
                return true;
        }
    }
}
