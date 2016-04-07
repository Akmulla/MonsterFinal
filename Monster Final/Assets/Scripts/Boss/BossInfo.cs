using UnityEngine;
using System.Collections.Generic;

public class BossInfo : MonoBehaviour
{
    public string HitByObjectsOfType = "Object";
    public float rageCoefficient = 1;

    float rage;
    public float maxRage;
    public float rageIncreaseSpeed;
    public float rageIncreaseValue;


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
        List<Component> abilities = GameObject.Find("AbilityManager").GetComponent<AbilityManager>().abilities;
        Component component = abilities[Random.Range(0, abilities.Count)];
        abilities.Remove(component);
        System.Type type = component.GetType();
        Component addedComponent=gameObject.AddComponent(type);

        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(addedComponent, field.GetValue(component));
        }
        //gameObject.AddComponent<Sniper>();
    }

    public float Rage
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
