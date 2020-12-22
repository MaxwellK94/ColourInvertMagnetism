using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetChase : MonoBehaviour
{



    public static List<Magnet> nearbyMagnets = new List<Magnet>();
    Rigidbody rb;
    float speed;
    Vector3 direction = new Vector3();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        //TODO: Create formula for attraction between several magnets
        //something like Vector3(modifier*Mathf.Sum(i foreach i in nearbyMagnets)\distance) 
        
        foreach(var m in nearbyMagnets){
            if (m.isMagnet){
                rb.velocity += ((m.gameObject.transform.position - transform.position).normalized);
            }
        }
    }

    void OnTriggerEnter(Collider col){
        
        if (col.gameObject.GetComponent<Magnet>()!=null){
            nearbyMagnets.Add(col.gameObject.GetComponent<Magnet>());
        }
    }

    void OnTriggerExit(Collider col){
        if( nearbyMagnets.Contains(col.gameObject.GetComponent<Magnet>()) ){
            nearbyMagnets.Remove(col.gameObject.GetComponent<Magnet>());
        }
    }
}
