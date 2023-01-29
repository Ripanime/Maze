using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// Contains "with timer" and "can die" variations
/// </summary>
public enum GameType1
{
    withoutAnything,
    withTimer,
    canDie,
    withTimerAndCanDie
};
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameType1 gameType;
    [SerializeField] private Timer timer;
    private PathController[] paths;
    public UnityEvent OnGameWinEvent;
    public UnityEvent OnGameLoseEvent;
    private bool isStopped = false;
    void Start()
    {
        paths = (PathController[])GameObject.FindObjectsOfType(typeof(PathController));
    }
    public void OnGameLose() 
    {
        OnGameLoseEvent.Invoke();
        OnGameType(true);
        isStopped = true;
    }
    public void OnGameWin() 
    {
        OnGameWinEvent.Invoke();
        OnGameType(true);
        isStopped = true;
    }
    public void OnGamePause(bool isActive) 
    {
        if (!isStopped) 
        {
            OnGameType(isActive);
        }
    }
    public bool GetStoppedGame() 
    {
        return isStopped;
    }
    public void Paths(bool Active) 
    {
        foreach (var path in paths)
        {
            path.canMove = Active;
        }
    }
    public void OnGameType(bool isActive) 
    {
        switch (gameType) 
        {
            case GameType1.canDie:
                Paths(!isActive);
                break;
            case GameType1.withTimer:
                timer.isTimerStopped = isActive;
                break;
            case GameType1.withTimerAndCanDie:
                Paths(!isActive);
                timer.isTimerStopped = isActive;
                break;
        }
    }
}
