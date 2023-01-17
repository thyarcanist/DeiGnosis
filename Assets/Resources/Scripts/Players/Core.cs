using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public string actorName;

    public float health;
    public behaviorPriority healthUrgency;

    bool isInCombat;
    bool isUsingItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

    }
}

public enum behaviorPriority
{
    Low,
    Medium,
    High,
    Urgent
}
