using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlspeed;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2;
    [SerializeField] float controlPitchFactor = -10;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = 20f;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localRotation.y * positionPitchFactor;
        float pitvhDueToControlTrhow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitvhDueToControlTrhow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //Horizontal movement parameters
         xThrow = Input.GetAxis("Horizontal");
        float rawXPos = transform.localPosition.x + xThrow * Time.deltaTime * controlspeed;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //Vertical movement parameters
         yThrow = Input.GetAxis("Vertical");
        float rawYPos = transform.localPosition.y + yThrow * Time.deltaTime * controlspeed;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
