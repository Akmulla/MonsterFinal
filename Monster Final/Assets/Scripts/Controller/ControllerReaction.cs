using UnityEngine;
using System.Collections;

public class ControllerReaction : MonoBehaviour
{
    public bool stunned;
    public float stunDuration;

    void Start()
    {
        stunned = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!stunned)
        {
            if (other.CompareTag("DangerZone"))
            {
                GetHit();
            }
        }
    }

    void GetBonus()
    {

    }
    void GetHit()
    {
        stunned = true;
        StartCoroutine(Stun());
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunDuration);
        stunned = false;
    }
}
