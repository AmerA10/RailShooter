using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 50f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 50f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yMinRange = -5f;
    [SerializeField] float yMaxRange = 5f;

    [Header("Screen-positionBased")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -25f;

    [Header("Control-ThrowBased")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -5f; 

    float xThrow, yThrow;
    bool isControlEnabled = true;


    [SerializeField] GameObject[] guns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProccessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
     

    }
    
    void OnPlayerDeath()
    {
        Debug.Log("Controls are frozen");
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; // add a certian rotation depending on the direction and amount of movement in a direction
        float pitchDueToControlThrow = controlPitchFactor * yThrow;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = controlRollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProccessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset; //raw because it is unclamped
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            Debug.Log("firing");
            SetGunsActivate(true);
        }
        else
        {
            SetGunsActivate(false);
        }
    }
    private void SetGunsActivate(bool isActive)
    {
        foreach(GameObject gun in guns)
        {
            var pS = gun.GetComponent<ParticleSystem>().emission;
            pS.enabled = isActive;
        }
    }
 
}
