using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float roomWidth = 30f;
    public float roomHeight = 30f;//30 por poner algo

    void Update () {
	
	}

    public void ChangeRoom()
    {
        //caso de habitaciones normales
        /*if (GameObject.Find("Personaje").GetComponent<Movement>().grounded3)
        {
            this.transform.Translate(new Vector3(0, roomHeight, 0));
        }
        else if (GameObject.Find("Personaje").GetComponent<Movement>().grounded0)
        {
            this.transform.Translate(new Vector3(0, -roomHeight, 0));
        }
        else */if (GameObject.Find("Personaje").GetComponent<Movement>().facingRight)
        {
            this.transform.Translate(new Vector3(roomWidth, 0, 0));
        }
        else
        {
            this.transform.Translate(new Vector3(-roomWidth, 0, 0));
        }
        
    }

}
