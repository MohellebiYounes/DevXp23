using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ; //  outil permettant de créer et de gérer des informations textuelles
// ce script a pour but de changer (incrementer) le chiffre qui est le nombre de diamant collecté a chaque fois q'un diamant est collecté par jhon lemon
public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText ; //champ privé pour le text du diamant 
    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI> () ;// mettre le composant de TextMeshPRO dans la variable diamondText
    }

   public void UpdateDiamondText(PlayerInventory playerInventory)  // fonction pour mettre a jour le text de nombre de diamant collecté 
   // comme paramettre de la fonction le script PlayerInventory pour acceder a la fonction qui incremente le nombre de daimanat collecté et le mettre dans la variable diamondText
   {
    diamondText.text=playerInventory.NumberOfDiamonds.ToString() ;  // mettre le nombre de diamant dans le diamantText (qui est sur l'ecran)
   }
}
