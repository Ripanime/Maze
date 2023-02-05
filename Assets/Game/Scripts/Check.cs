using UnityEngine;

public class Check : MonoBehaviour
{
    public void OnPlayerEnter() 
    {
        Destroy(this.gameObject);
    }
}
