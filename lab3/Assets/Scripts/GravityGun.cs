using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    int layerMask = 1 << 8;
    GameObject heldObject = null;
    public Transform holdPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (heldObject == null)
            {
                RaycastHit colliderHit;
                if (Physics.Raycast(transform.position, transform.forward, out colliderHit, 10.0f, layerMask))
                {
                    heldObject = colliderHit.collider.gameObject; heldObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        if (heldObject != null)
        {
            // move the thing we're holding
            heldObject.GetComponent<Rigidbody>().MovePosition(holdPosition.position);
            heldObject.GetComponent<Rigidbody>().MoveRotation(holdPosition.rotation);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // drop the object again
            if (heldObject != null)
            {
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().ResetInertiaTensor();
                heldObject = null;
            }
        }

    }
}
