using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events ; // pour creer des evenement 

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfDiamonds {get;  set ;} // variable pour stocker le nombre de diamant collecté (peut étre lu par un autre script mais modifaible que par celui la)
   public UnityEvent<PlayerInventory> OnDiamondCollected ; //l'evenment prend un argument de type de type PlayerInventory 
   // nom de levenement OnDiamondCollected 
   public bool IsAllDiamsCollected ; // true si jhon lemon a collecter tout les diamant 

   public void DiamondCollected () { // methode pour incrementer le nombre de diamond collecté
    NumberOfDiamonds ++ ;
    // nous allons appeler l'event 
    OnDiamondCollected.Invoke(this) ; 
    // chaque fois qu'un diamant est collecté l'evenement se declanche et appel la methode UpdateDiamondText du script InventoryUI 

   }    
    void Update () {
        if (NumberOfDiamonds == 4) { 

            IsAllDiamsCollected = true ; // rendre cette variable true si jhon lemon a collecter tout les diamant 
        }
    }
}
