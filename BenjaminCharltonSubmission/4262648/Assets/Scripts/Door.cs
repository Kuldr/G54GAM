using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open;
    Vector3 openPos;
    Vector3 closedPos;
    public GameObject doorBlock;
    public GameObject doorLight;
    public Material GreenLight;
    public Material RedLight;

    // Start is called before the first frame update
    void Start()
    {
        if(open) {
            openPos = doorBlock.transform.position;
            closedPos = doorBlock.transform.position + Vector3.up * 3;
            doorLight.GetComponent<Renderer>().material = GreenLight;
        } else {
            openPos = doorBlock.transform.position + Vector3.down * 3;
            closedPos = doorBlock.transform.position;
            doorLight.GetComponent<Renderer>().material = RedLight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(open) {
            doorBlock.transform.position = Vector3.MoveTowards(doorBlock.transform.position, openPos, 0.125f);
        } else {
            doorBlock.transform.position = Vector3.MoveTowards(doorBlock.transform.position, closedPos, 0.125f);
        }
    }

    public void Trigger()
    { 
        if (open) {
            doorLight.GetComponent<Renderer>().material = RedLight;
            this.open = false;
        } else {
            doorLight.GetComponent<Renderer>().material = GreenLight;
            this.open = true;
        }
    }
}
