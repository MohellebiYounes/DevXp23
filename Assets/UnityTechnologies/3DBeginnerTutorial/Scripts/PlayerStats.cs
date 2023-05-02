
using UnityEngine;
using UnityEngine.UI ;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float maxHealth = 100f; // nombre de point vie maximum du joueur 

    [SerializeField]
    public float currentHealth; // vie actuelle joueur 

    [SerializeField]
    public Image HelthBarFill ; // ref a notre image de vie du personnage
    public Observer Observer ;  
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth ; //vie actuelle est egal a vie maximal (au debut du jeu)
    }
    /*void Update() {
        if(Observer.m_IsTakeDamge) {
            TakeDamage(15f) ;
            UpdateHelthBarFill() ;
        }
    }*/
   
    public void TakeDamage(float damage) // fonction decremente la vie quand on a des degas sur le personnage 
    {
        currentHealth -=damage ; // decrementer les points de vie actuelles 

    }
    public void UpdateHelthBarFill() { // va deminuer la vie a l'ecran (dans le cercle de vie )
        HelthBarFill.fillAmount = currentHealth/maxHealth ; // mettre a jour la valeur de fill Amount ce qui donne l'effet de diminuation du rouge dans le cercle de vie 
    }
}
