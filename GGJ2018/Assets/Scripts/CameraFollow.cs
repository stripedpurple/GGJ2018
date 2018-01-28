using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x + 6, player.position.y, -20); // Camera follows the player but 6 to the right
    }
}
