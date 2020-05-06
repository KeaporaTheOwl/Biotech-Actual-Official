using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will displayin the UI when the player looks at this object in the world.")]
    [SerializeField] protected string displayText = nameof(InteractiveObject);

    public virtual string DisplayText => displayText;

    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch(System.Exception)
        {
            throw new System.Exception("Missing AudioSource component or audio clip: InteractiveObject requires an AudioSource Component with an audio clip assigned.");
        }
        Debug.Log(this.gameObject.transform.position);
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
