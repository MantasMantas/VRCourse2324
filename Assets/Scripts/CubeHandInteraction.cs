using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeHandInteraction : MonoBehaviour
{
    public float MultiplierForce;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Hand")) 
        {
            Vector3 DirectionForce = other.transform.forward;
            float AppliedForce = other.gameObject.GetComponentInParent<HandVelocityTracker>().GetVelocityMagnitude();
            Debug.Log(AppliedForce);
           
            
            rb.AddForce(DirectionForce * (AppliedForce * MultiplierForce));
        }
    }
}
