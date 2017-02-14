using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        GM.instance.LoseLife();
    }
}
