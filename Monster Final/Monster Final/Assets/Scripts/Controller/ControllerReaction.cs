using UnityEngine;
using System.Collections;

public class ControllerReaction : MonoBehaviour
{
    public bool stunned;
    public float stunDuration;
    public GameObject Boss;
    private BossInfo bossInfo;
    private Animator anim;
    private ControllerVerticalMove vert;
    public Collider2D pushCollider;
    public LayerMask objectLayer;
    public rotate rotateObj;
    private Rigidbody2D rb;

    void Start()
    {
        stunned = false;
        bossInfo = Boss.GetComponent<BossInfo>();
        anim = GetComponentInChildren<Animator>();
        vert = GetComponent<ControllerVerticalMove>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (!pushCollider.IsTouchingLayers(objectLayer))
        //{
        //    EndPush();
        //}

        if (rb.velocity.x != 0.0f)
        {
            anim.SetBool("RunRight", true);
        }
        else
        {
            anim.SetBool("RunRight", false);
        }
        if ((pushCollider.IsTouchingLayers(objectLayer))&&(rb.velocity.magnitude>0.1f))
        {
            rotateObj.Rotate();
            Push();
        }
        else
        {
            rotateObj.StopRotate();
            EndPush();
        }
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
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if ((Physics2D.IsTouching(coll.collider, pushCollider))&&(!stunned))
    //    {
    //        Push();
    //    }
    //}

    void GetBonus()
    {
        //bossInfo.Rage -= 15 * bossInfo.bonusCoefficient;
    }
    void GetHit()
    {
        anim.SetBool("Stun", true);
        stunned = true;
        StartCoroutine(Stun());
        //vert.speed = 0.0f;
    }
    void EndStun()
    {
        anim.SetBool("Stun", false);
        stunned = false;
    }
    void Push()
    {
        anim.SetBool("Push", true);
    }
    void EndPush()
    {
        anim.SetBool("Push", false);
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunDuration);
        EndStun();
    }
}
