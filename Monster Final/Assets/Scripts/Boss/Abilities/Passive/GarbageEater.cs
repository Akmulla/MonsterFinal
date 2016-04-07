using UnityEngine;
using System.Collections;

public class GarbageEater : MonoBehaviour
{
    BossInfo bossInfo;
	// Use this for initialization
	void Start ()
    {
        bossInfo = GetComponent<BossInfo>();
        bossInfo.HitByObjectsOfType ="None";
        bossInfo.rageCoefficient = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
