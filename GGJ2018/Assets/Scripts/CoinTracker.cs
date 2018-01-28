using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour {

    private Text coinsCounter = null;

    void Awake()
    {
        if (coinsCounter == null)
        {
            coinsCounter = gameObject.GetComponent<Text>();
        }
    } 

    void Update()
    {
        coinsCounter.text = string.Format("Points: {0}", CoinCollectible.coins);
    } 

}
