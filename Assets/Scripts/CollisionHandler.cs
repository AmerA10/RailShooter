using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok to have as long as only script that loads scene on the object
public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        deathFX.SetActive(true);
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   private void StartDeathSequence()
   {
        
        SendMessage("OnPlayerDeath"); //
        
   }
}
