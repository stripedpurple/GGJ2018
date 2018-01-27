using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerScript : Transmission {

    public string[] prompt;

    public override void Interact()
    {
        player.GetComponent<Player>().SetCanMove(false);
        TextPrompts.Instance.AddNewDialogue(prompt, name);
        Debug.Log("RADIO"); //delete this
        StartCoroutine(CheckForPromptEnd());
    }

    IEnumerator CheckForPromptEnd()
    {
        while (TextPrompts.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        currentState = States.IDLE;
        player.GetComponent<Player>().SetCanMove(true);
    }
}
