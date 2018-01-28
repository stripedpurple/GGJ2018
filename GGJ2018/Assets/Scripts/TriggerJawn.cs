using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerJawn : Transmission {

    public string[] prompt;

    public override void Interact()
    {
        player.GetComponent<Player>().SetCanMove(false);
        TextPrompts.Instance.AddNewPrompt(prompt, name);
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
