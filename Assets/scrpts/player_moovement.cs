using UnityEngine;

public class player_moovement : MonoBehaviour
{
  public float mooveSpeed;//déclaration de la vitessse de déplacement
  public Rigidbody2D rb;//décalration du rigidbody de notre personnage, l'on va s'en servir pour le faire se déplacer par la suite
  public bool isJumping=false;
  public float jumpForce;
  private Vector3 velocity= Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if(Input.GetButtonDown("Jump"))//detect l'appuie du bt jump (barre espace)
        {
          isJumping=true;

        }
      



    }

    void FixedUpdate()
    {
      //calcul du mouvement, vitesse + direction
      float horizontalMouvement= Input.GetAxis("Horizontal")*mooveSpeed*Time.deltaTime; //get axis permet de récuperer les axes,// time.deltatime fait que aussi longtemps que l'on appuie sur la touceh du clavier notre personnage se déplace

      MovePlayer(horizontalMouvement);//méthode qui déplace le joueur


    }
    void MovePlayer(float _horizontalMouvement)
    {
      Vector3 targetVelocity= new Vector2(_horizontalMouvement, rb.velocity.y);//la direction dans laquelle on va se déplacer va etre basé sur horizontal mouvement(axe X) et on utilise le RB sur y
      rb.velocity=Vector3.SmoothDamp(rb.velocity,targetVelocity, ref velocity,0.05f);

      if(isJumping==true)
      {
        rb.AddForce(new Vector2(0f,jumpForce));// on ajoute une force sur l'axe y
        isJumping=false;
      }

    }//méthode qui déplace le joueur

}
