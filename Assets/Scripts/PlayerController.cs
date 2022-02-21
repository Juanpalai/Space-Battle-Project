using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlspeed;
    // Update is called once per frame
    void Update()
    {

        float xThrow = Input.GetAxis("Horizontal");        

        float yThrow = Input.GetAxis("Vertical");


        float newxPos = transform.localPosition.x + xThrow * Time.deltaTime * controlspeed;
        float newyPos = transform.localPosition.y + yThrow * Time.deltaTime * controlspeed; 

        transform.localPosition = new Vector3(newxPos, newyPos, transform.localPosition.z);
        
    }
}
