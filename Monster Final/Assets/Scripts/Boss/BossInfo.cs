using UnityEngine;
using System.Collections.Generic;

public class BossInfo : MonoBehaviour
{
    public string HitByObjectsOfType = "Object";
    int rage;
    public int maxRage;
	// Use this for initialization
	void Start ()
    {
        GetAbilities();
        rage = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GetAbilities()
    {
        //List<Component> abilities = GameObject.Find("AbilityManager").GetComponent<AbilityManager>().abilities;
        //Component component = abilities[Random.Range(0, abilities.Count)];
        //gameObject.AddComponent<Sniper>();
    }

    public int Rage
    {
        get
        {
            return rage;
        }
        set
        {
            if ((value <= maxRage) && (value >= 0))
            {
                rage = value;
            }
            else
            {
                if (value > maxRage)
                {
                    rage = maxRage;
                }
                else
                {
                    if (value < 0)
                    {
                        rage = 0;
                    }
                }
            }
        }
    }


}
