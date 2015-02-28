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
            if (Input.GetAxis("Horizontal") > 0)
            {
                RotateDroite();
            }
			else if (Input.GetAxis("Horizontal") < 0)
            {
                RotateGauche();
            }         
        }
        else if (frames >= moveXFrame)
        {
            frames = 0;
        }
        frames++;

        if (Map.Instance.isStarted() && Input.GetKeyDown(KeyCode.Space)){
            lancerTours();
        }

		if(Map.Instance.isGameOver() && Input.GetAxis("Fire1") > 0)
		{
			Map.restartInstance();
			Application.LoadLevel("MainMenu");
		}

    }

    // Fonction de rotation vers la droite
    void RotateDroite()
    {
        if (rotation < 35 && rotation >= -35) {
			leTransform.Rotate(Vector3.up, Mathf.Abs(Input.GetAxis("Horizontal")));
            rotation++;
          
        }
    }
     // Fonction de rotation vers la gauche
    void RotateGauche()
    {
        if (rotation <= 35 && rotation > -35) {
			leTransform.Rotate(Vector3.down, Mathf.Abs(Input.GetAxis("Horizontal")));
            rotation--;
        }
    }

    void lancerTours() { }
}
