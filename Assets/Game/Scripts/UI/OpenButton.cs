using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public bool isClosed { get; private set; }
    [SerializeField] private string buttonDownAnim;
    [SerializeField] private string buttonUpAnim;
    [SerializeField] private GameObject state;
    [SerializeField] private GameManager manager;
    private int clickCount;
    private const int closeButton = 2;
    private const int openButton = 0;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        clickCount = openButton;
    }
    public void OnClick()
    {
        clickCount++;
        bool gamePauseIsActive = clickCount < closeButton;
        if (gamePauseIsActive)
        {
            OnPauseActive(buttonUpAnim, gamePauseIsActive);
            if (BonusActivateCall.isActive)
            {
                isClosed = !gamePauseIsActive;
                BonusOff.BonusSwitch(gamePauseIsActive);
            }
            else 
            {
                state.SetActive(gamePauseIsActive);
            }
        }
        else
        {
            isClosed = !gamePauseIsActive;
            OnPauseActive(buttonDownAnim, gamePauseIsActive);
            clickCount = openButton;
            if (BonusActivateCall.isActive)
            {
                BonusOff.BonusSwitch(gamePauseIsActive);
            }
            else
            {
                state.SetActive(gamePauseIsActive);
            }
        }
    }
    private void OnPauseActive(string buttonAnim, bool pauseIsActive)
    {
        anim.SetTrigger(buttonAnim);
        manager.OnGamePause(pauseIsActive);
    }
}
