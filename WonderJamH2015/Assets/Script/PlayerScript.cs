using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public Transform leTransform;
    public float moveXFrame = 10;
    public byte mode; // 0 = tourMode 1 = gun mode
    float frames;
    float rotation;
    


    // Use this for initialization
    void Start()
    {
        moveXFrame = 10;
        rotation = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frames < moveXFrame)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                RotateDroite();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                RotateGauche();
            }         
        }
        else if (frames >= moveXFrame)
        {
            frames = 0;
        }
        frames++;

        if (Input.GetKeyDown(KeyCode.Space)){
            lancerTours();
        }

    }

    // Fonction de rotation vers la droite
    void RotateDroite()
    {
        if (rotation < 35 && rotation >= -35) {
            leTransform.Rotate(Vector3.up, 1);
            rotation++;
          
        }
    }
     // Fonction de rotation vers la gauche
    void RotateGauche()
    {
        if (rotation <= 35 && rotation > -35) {
            leTransform.Rotate(Vector3.down, 1);
            rotation--;
        }
    }

    void lancerTours() { }
}
