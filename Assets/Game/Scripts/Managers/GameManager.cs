using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// Contains "with timer" and "can die" variations
/// </summary>
public enum GameType
{
    withoutAnything,
    withTimer,
    canDie,
    withTimerAndCanDie
};
public class GameManager : MonoBehaviour
{
    public bool isStopped { get; private set; }
    [SerializeField] private GameType gameType;
    [SerializeField] private Timer timer;
    private PathController[] paths;
    public UnityEvent OnGameWinEvent;
    public UnityEvent OnGameLoseEvent;
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
            case GameType.canDie:
                Paths(!isActive);
                break;
            case GameType.withTimer:
                timer.isTimerStopped = isActive;
                break;
            case GameType.withTimerAndCanDie:
                Paths(!isActive);
                timer.isTimerStopped = isActive;
                break;
        }
    }
}
