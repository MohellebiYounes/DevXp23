using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimGohst : MonoBehaviour
{
    Animator animator ; // variable qui fait ref au composant animtor 
    public WalkGh walkGh ; // ref au script WalkGh pour utiliser ces fonctions  
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> (); //Obtenir une référence à un composant de type 'Animator' et l'affecter à la variable appelée animator
        navMeshAgent.enabled= false ; // desactiver la navmesh au debut pour le gost puisse rentrer dans l'animation de l'eau (prend une douche)
    }


    // Update is called once per frame
    void Update()
    {
        if (walkGh.m_IsPlayerOn)  // si jhon lemon rentre dans trigger a l'entrée de la douche 
        {
            navMeshAgent.enabled = true ; // activer navmesh agent 
            animator.SetBool("GohstWalk" , true) ; // changer l'animation du ghost (de ghost shower --> ghost walk)
            
        }
        

    }
}
