using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*ce script a pour but de creer un trigger qui detecte que jhon
lemon est reperé la le gargoyle ou par le ghost  , fin de la parie )*/

public class Observer : MonoBehaviour
{
    public Transform player; // detecter le personnage( Ce script vérifiera le transform du personnage)
    public GameEnding gameEnding; // ref au script GameEnding pour utiliser ces fonctions et variables 
    public PlayerStats PlayerStats ; // reference au script PlayerStats pour utiliser ces fonctions et variables 
    public bool m_IsPlayerInRange; // vrai si le peronnage rentre dans le trigger
   
    void OnTriggerEnter (Collider other) // le player entre daans le trigger
    {
        if(other.transform == player) // si c'est bien jhon lemon qui est entré dans le trigger
        {
            m_IsPlayerInRange = true; 
        }
         if(m_IsPlayerInRange) // verifier si jhon lemon est a prté du gargoyle ou du ghost
        {
            //calcul de la direction de la ligne entre le gameobject et jhon lemon
            Vector3 direction = player.position - transform.position + Vector3.up;
            // creer un rayon (param1 : l'origine / param2 : la direction)
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit; // cette variable contiendra l'objet touché par le raycast

            if(Physics.Raycast(ray, out raycastHit))
             //Raycast renvoie un bool qui est vrai lorsqu'il a touché quelque chose et faux lorsqu'il n'a rien touché.  
             // Le bloc de code de l'instruction if ne sera exécuté que si le Raycast a touché quelque chose. 
             //out raycastHit permet de recuperer l'objet qu'on a touché
            {
                if(raycastHit.collider.transform == player) // si l'objet qui a été touché par le raycast est bien john lemon
                {

                   PlayerStats.TakeDamage(15f) ; // appliquer des degats sur le personnage 
                   PlayerStats.UpdateHelthBarFill() ; // mettre a jour le cercle de vie 
                 
                }
            }
        }
    }
   /* void OnTriggerExit (Collider other) {
         if(other.transform == player) // si c'est bien jhon lemon qui est entré dans le trigger
        {
            m_IsTakeDamge = false ;
        }
    }*/
    
    void Update () // appel a chaque image 
    {
        if(PlayerStats.currentHealth <= 0 ) { // si la vie de jhon est 0

            gameEnding.CaughtPlayer (); // fin de la partie (la fonction Caughtplayer met la variable m_IsPlayerCaught a vrai)
        }
    }
     
       

    

}
