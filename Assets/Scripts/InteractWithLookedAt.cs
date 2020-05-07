using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the Interact button while looking at an IInteractive,
/// and then calls that IInteractive's InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            Debug.Log("Player pressed the Interact button.");
            lookedAtInteractive.InteractWith();
        }
    }


    /// <summary>
    /// Event Handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive that the player is looking at.</param>
    
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event subscription/ unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
