using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the associated object's icon.")]
    [SerializeField] private Image iconImage;

    private InventoryObject associatedInventoryObject;

    public static event Action<InventoryObject> InventoryMenuItemSelected;
    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }
    
    /// <summary>
    /// This will be plugged into the toggle's "OnValueChanged" property in the editor and called whenever the toggle is clicked.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        // We only want to do the stuff when the toggle has been selected. Not when it has been deselected.
        if(isOn)
        {
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        }

        Debug.Log($"Toggled: {isOn}");
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
