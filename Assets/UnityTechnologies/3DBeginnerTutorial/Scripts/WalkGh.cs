using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ce script va configurer le trigger de la douche de sorte quand jhon lemon rentre le ghost le voit et s'arrete de se doucher pour sortir et verifier

public class WalkGh : MonoBehaviour
{
    public GameObject player; // ref a jhon lemon
    public bool m_IsPlayerOn; // true si jhon lemon rentre dans la douche
    public GameObject ghost  ;
    public WaypointPatrol waypointPatrol ;
    

    void OnTriggerEnter (Collider other) 
    {

        if (other.gameObject == player)
        {
            m_IsPlayerOn = true ; // si jhon lemon rentre dans le trigger mettre la variable a vrai 
        }
    
         
    }
    // Update is called once per frame
    void Update()
    {
      if (m_IsPlayerOn) {
        waypointPatrol.WalkGohst() ; // si jhon lemon est rentré dans la douche , il sera reperer par le ghost 
        // WalkGohst fais marcher le fantomme (il sort de la douche pour verifier) 
      }   
    }
}
