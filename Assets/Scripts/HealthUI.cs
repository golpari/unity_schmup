using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HasHealth.instance.lostLife == true)
        {
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                if (child.gameObject.CompareTag("Life"))
                {
                    Destroy(child.gameObject);
                    break;
                }
            }
            HasHealth.instance.lostLife = false;
        }
    }
}
