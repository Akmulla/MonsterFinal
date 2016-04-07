using UnityEngine;
using System.Collections;

public class BossReaction : MonoBehaviour
{
    Animator anim;
    BossInfo bossInfo;

    // Use this for initialization
    void Start()
    {
        bossInfo = GetComponent<BossInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(bossInfo.HitByObjectsOfType))
        {
            HitByObject();
        }
        else
        if (other.gameObject.CompareTag("Bonus"))
        {
            GetBonus();
        }
    }

    void HitByObject()
    {
        bossInfo.Rage += 10;
    }

    void GetBonus()
    {
        bossInfo.Rage -= 15;
    }
}
