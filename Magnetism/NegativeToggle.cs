using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeToggle : MonoBehaviour
{
    MeshRenderer filterSphere;
    public MeshRenderer ball;
    List<MeshRenderer> cylinderRenderers;
    Magnet[] cylinderMagnets;
    public Collider posCol;
    public Collider negCol;
    
    int touchcount;
    Collider lastTouched;
    Collider lastExited;

    void Start()
    {   
        filterSphere = GetComponentInChildren<MeshRenderer>();
        filterSphere.enabled=false;

        touchcount = 0;
        
        cylinderMagnets = FindObjectsOfType<Magnet>();    
        cylinderRenderers = new List<MeshRenderer>();

        foreach (Magnet m in cylinderMagnets){            
        cylinderRenderers.Add(m.gameObject.GetComponent<MeshRenderer>());
        }      
    }
    

    void toggleNegativeOn(){
        foreach(MeshRenderer r in cylinderRenderers){
            r.enabled=true;    
        }
        filterSphere.enabled=true;
        ball.enabled = false;
    }

    void toggleNegativeOff(){
        foreach(Magnet m in cylinderMagnets){
            //if(!m.isMagnet){
                m.GetComponent<MeshRenderer>().enabled = false;     
            //}
            filterSphere.enabled=false;
            ball.enabled=true;
        }
    }


    /*
    The doorway contains two colliders. 
    The below Trigger fuctions check that contact has been made with both colliders, 
    then enables/disables the filter dependent on the collider last exited.
    */
    void OnTriggerEnter(Collider c){
        if (c == negCol || c == posCol){
            touchcount+=1;
        }

    }
    void OnTriggerExit(Collider c){
        if (c == negCol || c == posCol){
                touchcount-=1;
                lastTouched = c;
            }

        if (touchcount == 1){

            if (lastTouched == negCol){
                toggleNegativeOff();
            }
            
            else if(lastTouched == posCol){
                toggleNegativeOn();
            }
        }

    }
}
