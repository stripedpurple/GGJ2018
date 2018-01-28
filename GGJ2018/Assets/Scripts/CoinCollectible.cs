using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour {

    public static int coins = 0;
    public int coinsToGive = 0;
    public Color debugColor = Color.yellow;
    private GameObject disableOnCollect = null;
    

    void OnDrawGizmos()
    {
        Gizmos.color = debugColor;

        if (disableOnCollect != null && disableOnCollect.activeSelf)
        {
            Gizmos.DrawLine(transform.position, disableOnCollect.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            OnCollect();
        }
    }

    //void OnCollisionEnter2D(Collider2D target)
    //{
        //if (target.gameObject.tag == "Player")
        //{
           // OnCollect();
           // Destroy(gameObject);
        //}
   // }

    void OnCollect()
    {
        coins += coinsToGive;
        OpenDoor();
        gameObject.SetActive(false);
        Destroy(gameObject);

    }

    bool IsPlayer(GameObject targetObject)
    {
        Player player = targetObject.GetComponent<Player>();
        return player != null;
    }

    void OpenDoor()
    {
        if (disableOnCollect == null)
            return;
        disableOnCollect.SetActive(false);
    }
}
