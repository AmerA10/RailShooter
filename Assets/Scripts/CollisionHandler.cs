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
        StartDeathSequence();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   private void StartDeathSequence()
   {
        Debug.Log("Player is dead");
        SendMessage("OnPlayerDeath");
   }
}
