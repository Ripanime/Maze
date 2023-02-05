using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CheckTrecker : MonoBehaviour
{
    public bool Checked = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Check check)) 
        {
            Debug.Log("def");
            Checked = true;
            check.OnPlayerEnter();
        }
    }
}
