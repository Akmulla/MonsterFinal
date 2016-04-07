using UnityEngine;
using System.Collections;

public class GarbageEater : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<BossInfo>().HitByObjectsOfType="None";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
