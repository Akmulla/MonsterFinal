﻿using UnityEngine;
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
    }

    void HitByObject()
    {
        bossInfo.Rage += 7;
    }
}
