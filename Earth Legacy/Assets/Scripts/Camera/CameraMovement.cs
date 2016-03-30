using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject player;

    private float delayToFind = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        
        if (player == null)
        {
            LookForPlayer();
            return;
        }

        this.transform.position = player.transform.position;

	}

    void LookForPlayer()
    {
        if(delayToFind <= Time.time)
        {
            GameObject founded = GameObject.FindGameObjectWithTag("Player");
            if(founded != null)
            {
                player = founded;
            }
            else
            {
                delayToFind = Time.time + 0.5f;
            }
        }
    }

}
