using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCheck : MonoBehaviour
{
    public MeshRenderer mr;
    int layerMask = 1 << 8;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && mr.enabled){
            Debug.Log("click");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;


            //Debug.Log(layerMask);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask)){
                //find polarity
                Color invertColor;
               
                GameObject o = hitInfo.transform.gameObject;
                bool m = o.GetComponent<Magnet>().isMagnet;

                //debug
                Debug.Log(hitInfo.transform.gameObject);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

                //invert color - alpha remains unchanged
                invertColor = hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color;
                invertColor[0] = 1-invertColor[0];
                invertColor[1] = 1-invertColor[1];
                invertColor[2] = 1-invertColor[2];
                hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = invertColor;

                //flip magnet
                o.GetComponent<Magnet>().isMagnet=!o.GetComponent<Magnet>().isMagnet;
            }

             
            
        
       
        }

    }
}
    

