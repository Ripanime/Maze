using UnityEngine;

public class Check : MonoBehaviour
{
    public bool Checked = false;
    [SerializeField] private string playerTag;
    private LevelFinish levelFinish;
    private void Awake()
    {
        levelFinish = GetComponentInParent<LevelFinish>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            Checked = true;
            levelFinish.CheckedChecks++;
            Destroy(this.gameObject);
        }
    }
}
