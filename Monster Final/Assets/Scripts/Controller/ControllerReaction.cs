using UnityEngine;
using System.Collections;

public class ControllerReaction : MonoBehaviour
{
    public bool stunned;
    public float stunDuration;
    public GameObject Boss;
    private BossInfo bossInfo;
    private Animator anim;
    private VerticalMove vert;

    void Start()
    {
        stunned = false;
        bossInfo = Boss.GetComponent<BossInfo>();
        anim = GetComponentInChildren<Animator>();
        vert = GetComponent<VerticalMove>();
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
        anim.SetBool("Stun", true);
        stunned = true;
        StartCoroutine(Stun());
        vert.speed = 0.0f;
    }
    void EndStun()
    {
        anim.SetBool("Stun", false);
        stunned = false;
        vert.speed = 1.0f;
    }
    IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunDuration);
        EndStun();
    }
}
