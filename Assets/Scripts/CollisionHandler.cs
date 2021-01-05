using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered something");
        if (other.transform.tag.Equals("Enemy"))
        {
            Debug.Log("Collided with enemy");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
