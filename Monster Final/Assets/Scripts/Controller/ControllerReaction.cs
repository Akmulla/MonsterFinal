using UnityEngine;
using System.Collections;

public class ControllerReaction : MonoBehaviour
{
    public bool stunned;
    public float stunDuration;
    public GameObject Boss;
    private BossInfo bossInfo;

    void Start()
    {
        stunned = false;
        bossInfo = Boss.GetComponent<BossInfo>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!stunned)
        {
            if (other.CompareTag("DangerZone"))
            {
                GetHit();
            }
            if (other.CompareTag("Bonus"))
            {
                GetBonus();
            }
        }
    }

    void GetBonus()
    {
        bossInfo.Rage -= 15 * bossInfo.bonusCoefficient;
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
