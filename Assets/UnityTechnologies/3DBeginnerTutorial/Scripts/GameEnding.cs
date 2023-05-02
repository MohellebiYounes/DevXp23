using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // utilise pour recharger la scene et recommancer la partie 
// ce script est un trigger pour  reconnaître que JohnLemon est sorti de la maison hantée
//signalent l'événement déclencheur de la fin du jeu 
public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; // temps pour que l'ecran s'efface (ajuster a partir de l'inspecteur) 1s par defaut 
    public float displayImageDuration = 1f; // temps suplémentaire d'ffichage (durée de l'image)
    public GameObject player; //spécifier que le fondu doit se produire lorsque le personnage du joueur touche le Trigger (référence à ce GameObject)
    public CanvasGroup exitBackgroundImageCanvasGroup; // image de fin de jeu (composant )
    public AudioSource exitAudio; // song de fin du jeu 
    public CanvasGroup caughtBackgroundImageCanvasGroup; // image de game over
    public AudioSource caughtAudio; // song de game over
    bool m_IsPlayerAtExit; // (true si jhon lemon rentre dans le tirgger , false sinon) 
    bool m_HasAudioPlayed; // true si le song est joué false sinon(pour s'asurer de le jouer une seule fois)
    bool m_IsPlayerCaught; // true si john lemon de fait attraper
    float m_Timer; // temps avant de quitter jeu (minuteur)
    public PlayerInventory playerInventory ; // pour acceder au a la variable NumberOfDiamonds de ce script 
   
    void OnTriggerEnter (Collider other) // le parametre collider correspend a l'objet qui rentre dans le trigger
    // cette fonction se lis au moment ou le gameobject entre dans la boite de collision (triger)
    {
        if (other.gameObject == player)
        /*Si l'objet de jeu de l'autre collisionneur (celui qui est entré dans le déclencheur) est équivalent à 
        notre référence à l'objet de jeu de JohnLemon, alors faites ce qui se trouve dans le bloc de code".*/
        {
            m_IsPlayerAtExit = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == player) 
        {
            m_IsPlayerAtExit = false ;
        }
    }
    // acces public a la variable m_IsPlayerCaught
     public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    //  vérifie si le personnage du joueur est à la sortie.  
    // Si le personnage du joueur est à la sortie, il passe dans le bloc de code de l'instruction if
    {
        
        if(m_IsPlayerAtExit && playerInventory.IsAllDiamsCollected) // si john lemon atteind la sortie et que il a recolté tout les diamant qu'il faut (la partie sera finie et gagné)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio); // fin de la partie et afficher l'image passé en paramétre , quitter le jeu
        } 
        else if(m_IsPlayerCaught) // verfier si jhon lemon s'est fait attraper  
        { 
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio); // fin de la partie , afficher l'image du canvas passé en parametre , et recommencer la partie 
        }
    
        
    }
    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource) 
    /*param1 : image a afficher 
    param2 : si oui ou non refaire la partie 
    param3 : l'audio a jouer*/
    
    {
        if(!m_HasAudioPlayed) // si laudio n'a pas été joué
        {
            audioSource.Play(); // jouer l,audio passé en paramere en haut .
            m_HasAudioPlayed = true; // reinisialiser (le morceau a été joué)
        }
        m_Timer += Time.deltaTime; // temps ecoulé depuis la derniére image 
        // alpha du canva soit etre 0 si le M_timer est a 0 et doit etre a 1 si m_timer a ateind la durlé du fondu.
        imageCanvasGroup.alpha = m_Timer / fadeDuration; // si alpha =1 limage saffiche (m_timer=fadeduration) // afficher l'image de game over ou de fin de la partie 
        if(m_Timer > fadeDuration + displayImageDuration) // quitter le jeu quand m_timer > temps du fondu (le temps du fondu aura finie)
        // a revoir
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0); // recharger la scene 0
            }
            else 
            {
                Application.Quit (); //quitter le jeu
            }
        }
    }

}
