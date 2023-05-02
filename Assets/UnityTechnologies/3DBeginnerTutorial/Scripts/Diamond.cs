using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
     
    
    private void OnTriggerEnter (Collider other) // declacheur (si jhon lemon touche le diamant )
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>() ; // si jhon lemon touche le diamant , reuperer le composant du script PlayerInventory (pour utilser la fonction d'incrementation)
            if (playerInventory != null ) 
            {
                playerInventory.DiamondCollected () ; // utiliser la methode DiamondCollected pour incrementer le nombre de diamant collecté 
                gameObject.SetActive(false) ; // si le diamant a ete recolté il ne s'affiche plus 
            }
           
    }
        
    
            
        
    
}