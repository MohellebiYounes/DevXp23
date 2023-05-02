using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // accés a la classe NavMeshAgent , indiquer à l'agent NavMesh la destination qu'il doit avoir, besoin d'une référence à cet agent
// ce script va définir la destination de l'agent Nav Mesh à la fois lorsque la scène est chargée pour la première fois et lorsque le fantôme a atteint sa destination
public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; // ref au NavMesh Agent dans l'inspecteur 
    public Transform[] waypoints; // Cette ligne de code déclare une variable publique appelée waypoints, qui est un tableau de Transforms(position des objets).
    int m_CurrentWaypointIndex; //  l'index actuel du tableau des points de repère.
   
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); // definie la destination initiale de l'agent Mesh
    }
    // Update is called once per frame
    void Update()
    {   
        WalkGohst () ;
    }
    public void WalkGohst () {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)

         /*vérifier si la distance restante jusqu'à la destination est inférieure à
         la distance d'arrêt  définie dans la fenêtre de l'inspecteur.(esq le fatomme est arrivé a destination)  */
        {
            // incrementer l'index actuelle , si c'est le dernier index revenir au premier index (0)
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            // definir la prochaine destination du fantomme    

            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        } 
         
    }
    

   
        
       
        
}


