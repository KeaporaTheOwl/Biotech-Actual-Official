﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MultipleLockDoor : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If the player has the key in their inventory, they can open the locked door.")]
    [SerializeField]
    private InventoryObject key0;

    [SerializeField]
    private InventoryObject key1;

    [Tooltip("If this is checked, the associated key will be removed from the player's inventory when the door is unlocked.")]
    [SerializeField] private bool consumesKey;

    [Tooltip("The text that displays when the player looks at the door while it's locked.")]
    [SerializeField] private string lockedDisplayText = "Locked";

    [Tooltip("Play this audio clip when the player interacts with a locked door without owning the key.")]
    [SerializeField] private AudioClip lockedAudioClip;

    [Tooltip("Play this audio clip when the player opens the door.")]
    [SerializeField] private AudioClip openAudioClip;

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
            {
                toReturn = HasKey0 ? $"Use {key0.ObjectName}" : lockedDisplayText;
                toReturn = HasKey1 ? $"Use {key1.ObjectName}" : lockedDisplayText;
            }
            else
            {
                toReturn = base.DisplayText;
            }

            return toReturn;
        }
    }
    //Need overload for contains that holds multiple objects.
    //Contains is somewhere in my Inventory class, probably InventoryObject
    private bool HasKey0 => PlayerInventory.InventoryObjects.Contains(key0);
    private bool HasKey1 => PlayerInventory.InventoryObjects.Contains(key1);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
    /// <summary>
    /// Using a constructor here to initialize DisplayText in the editor.
    /// </summary>
    public MultipleLockDoor()
    {
        displayText = nameof(MultipleLockDoor);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key0 != null || key1 != null)
        {
            isLocked = true;
        }
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (isLocked && !HasKey0 || !HasKey1)
            {
                audioSource.clip = lockedAudioClip;
            }
            else //If it's not locked, or if it's locked and we have the key...
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                isLocked = false;
                UnlockDoor();
            }
            base.InteractWith(); // This plays a sound effect!
        }
    }

    private void UnlockDoor()
    {
        if (key0 != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key0);
        }
        else if (key1 != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key1);
        }
    }
}
