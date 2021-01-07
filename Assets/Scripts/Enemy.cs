using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider selfBoxCollider;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform deathParent;
    ScoreBoard scoreBoard;

    [SerializeField] int scorePerHit = 12;
    [SerializeField] int maxHits = 3;
    void Start()
    {

        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        if(this.gameObject.GetComponent<BoxCollider>() == null)
        {
            selfBoxCollider = gameObject.AddComponent<BoxCollider>();
        } 
        else
        {
            selfBoxCollider = this.GetComponent<BoxCollider>();
        }

        
        selfBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        maxHits--;
        if(maxHits <= 0)
        {
            KillEnemy();
        }
        
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = deathParent;
        Destroy(gameObject);
    }
}
