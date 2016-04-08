using UnityEngine;
using System.Collections;

public class IncreaseRageByTime : MonoBehaviour
{
    BossInfo bossInfo;
    // Use this for initialization
    void Start ()
    {
        bossInfo = GetComponent<BossInfo>();
        StartCoroutine(IncreaseRage());
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator IncreaseRage()
    {
        while(true)
        {
            bossInfo.Rage += bossInfo.rageIncreaseValue;
            yield return new WaitForSeconds(bossInfo.rageIncreaseSpeed);
        }
    }
}
