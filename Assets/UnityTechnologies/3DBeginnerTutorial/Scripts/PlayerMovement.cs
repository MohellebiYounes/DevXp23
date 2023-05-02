using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// le but de ce script est de traduire les entrée de l'utilisateur sur le clavier en mouvement du personnage
public class PlayerMovement : MonoBehaviour // class pour affecter un script a un objet.
{
    Vector3 m_Movement; // var Vector3 local a la classe PlayerMouvement , stocker le mouvement du personnage 
    Quaternion m_Rotation = Quaternion.identity; // stocker une rotaion (absence de rotation)
    Animator m_Animator; //  var local pour Stocker une référence au composant Animator 
    Rigidbody m_Rigidbody; // var pour stocker un ref au composant rigidbody 
    AudioSource m_AudioSource; // referance du song de marche 

    public float turnSpeed = 20f; // la vitesse a laquel le personnage doit tourner (radian/s)
    public float runSpeed = 2f; // vitesse quand le personnage court 

    // 
    // fonction se lance toute seule , une seule fois directement au demarrage du jeu
    void Start()
    {
        
        m_Animator = GetComponent<Animator> (); //Obtenir une référence à un composant de type 'Animator' et l'affecter à la variable appelée m_Animator
        m_Rigidbody = GetComponent<Rigidbody> (); // mm chose que animator 
        m_AudioSource = GetComponent<AudioSource>(); // mmc chose
    }

    // Update is called once per frame(appelé a chaque image avant le rendu a l'ecran)

   void FixedUpdate ()
   // called every physics step
   //adjusting rigidbody objects
   //appelé exactement 50 fois par seconde.
    {
        // verifier les axes pour decider commment le personnage doit se deplacer 
        // l'utilisateur appuie sur l'une des touches (gauche droide haut bas ) , l'un des axes (horiz , vert) prend une valeur (1 ou -1) 
        // on stock la valeur de l'Axe comme suit :
        float horizontal = Input.GetAxis ("Horizontal");  //var local, stocker dans la variable horizontal le resultat de la fonction GetAxis(la valeur de l'axe d'entrée horizontale 1 ou -1)
        float vertical = Input.GetAxis("Vertical");  // stocker dans la variable Vertical le resultat de la fonction GetAxis(la valeur de l'axe d'entrée vertical)

        // definiton du vecteur de mouvement :
        // on recupére ces valeurs dans le Vector3 pour indiquer dans quel sens le personnage va se deplacer
        m_Movement.Set(horizontal, 0f, vertical); 
        m_Movement.Normalize (); // au cas ou les valeur de horizontal et vertical prennet la valeur 1 garder la mm amplitude
        // determiner si il y'a une entrèe horizontal ou vertical: 
        // false si (la valeur de horizontal = 0) , true sinon (grace a ! qui inverse le result du bolean)
        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        /* determiner si le personnage vas marcher ou pas :
        grace a l'operateur logique  || (ou) si hasHorizontalInput ou hasVerticalInput sont vrais, 
        alors isWalking est vrai, et sinon il est faux. */
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool ("IsWalking", isWalking); // affecter au paramètre Animator (IsWalking) creé precedement la valeur du bool isWalking
        if(isWalking) // si jhon lemon marche
        {
            if(!m_AudioSource.isPlaying) // si le song n'est pas en cours de lecture 
            {
                m_AudioSource.Play (); //jouer le song
            }

        }
        else // s'il s'arrete 
        {
            m_AudioSource.Stop (); //arreter le song
        }
        //crée une variable Vector3 appelée desiredForward.
        // transform.forward est un raccourci pour accéder à la composante Transform et obtenir son vecteur avant
        //Time.deltaTime est le temps écoulé depuis l'image précédente
        // créer un vecteur pour la direction voulu :
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f); // appliquer une rotation sur l'ancien vecteur pour obtenir le nouveau 
        m_Rotation = Quaternion.LookRotation (desiredForward); // crée une rotation dans la direction du parametre (desireForward)
    }
    // appliquer le mouvement et la rotation séparement 
    void OnAnimatorMove ()
    {
        // untiliser la fonction MovePosiion pour transmetre sa nouvelle position au rigidbody
        /* m_Rigidbody.position : position actuelle du rigid
        m_mouvement*...... sa nouvelle position */ 
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude); // Cette ligne de code met à jour la position du Rigidbody en fonction de la position actuelle, de l'entrée de mouvement et de la magnitude de deltaPosition du composant Animator
        m_Rigidbody.MoveRotation (m_Rotation); //elle définit la rotation du Rigidbody en fonction de la variable m_Rotation. 
        
        if (Input.GetKey(KeyCode.LeftShift)) {
            m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude/2 * runSpeed);
            /*si la touche Shift gauche est enfoncée, la méthode MovePosition du Rigidbody est utilisée pour déplacer l'objet. 
            Le mouvement est calculé en multipliant la variable m_Movement (qui représente l'entrée de mouvement de l'utilisateur) par la magnitude de deltaPosition de l'Animator, divisée par deux, puis multipliée par la variable runSpeed. 
            Cela permet de réduire la vitesse de mouvement lorsque la touche Shift est enfoncée.*/
           
        }
    }
}
