using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 50f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 50f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yMinRange = -5f;
    [SerializeField] float yMaxRange = 5f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -25f;
    [SerializeField] float controlRollFactor = -5f; 

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with something");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered something");
        if(other.transform.tag.Equals("Enemy"))
        {
            Debug.Log("Collided with enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProccessTranslation();
        ProcessRotation();

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
}
