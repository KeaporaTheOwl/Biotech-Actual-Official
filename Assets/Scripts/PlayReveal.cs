using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayReveal : MonoBehaviour
{
    private AudioSource revealAudio;
    private bool alreadyRevealed;

    private void Awake()
    {
        revealAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !alreadyRevealed)
        {
            revealAudio.Play();
            alreadyRevealed = true;
        }
    }

}
