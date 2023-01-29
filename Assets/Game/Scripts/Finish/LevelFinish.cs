using UnityEngine;
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
    [HideInInspector] public int CheckedChecks { get; set; }
    [SerializeField] private string textForCheck;
    [SerializeField] private GameType2 gameType;
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject door;
    [SerializeField] private TextMeshProUGUI text;
    private int allChecks;
    private Check[] checks;
    private TextEnable textEnable;
    private void Start()
    {
        checks = GetComponentsInChildren<Check>();
        textEnable = text.GetComponent<TextEnable>();
        allChecks = checks.Length;
    }
    private void Update()
    {
        switch (gameType) 
        {
            case GameType2.withChecks:
                if (!manager.GetStoppedGame())
                {
                    foreach (var check in checks)
                    {
                        if (check.Checked) 
                        {
                            if (CheckedChecks != allChecks)
                            {
                                textEnable.EnableText();
                                text.text = $"{allChecks - CheckedChecks}" + textForCheck;
                            }
                            else
                            {
                                door.SetActive(false);
                            }
                        }
                    }
                }
            break;
        }
    }
}
