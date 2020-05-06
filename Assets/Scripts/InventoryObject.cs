using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object, as it will appear in the inventory menu UI.")]
    [SerializeField] private string objectName = nameof(InventoryObject);

    [Tooltip("The text that will display when the player selects this object in the inventory menu.")]
    [TextArea(3, 8)]
    [SerializeField] private string description;

    [Tooltip("Icon to display for this item in the inventory menu.")]
    [SerializeField] private Sprite icon;

    public Sprite Icon => icon;
    public string Description => description;
    public string ObjectName => objectName;

    private new Renderer renderer;
    private Renderer[] childRenderers;
    private new Collider collider;
    private new Light light;

    private void Start()
    {
        //renderer = GetComponent<Renderer>();

        if(GetComponent<Renderer>())
        {
            renderer = GetComponent<Renderer>();
        }

        if(GetComponent<Light>())
        {
            light = GetComponent<Light>();
        }

        childRenderers = GetComponentsInChildren<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        //renderer.enabled = false;

        if(renderer)
        {
            renderer.enabled = false;
        }

        if(light)
        {
            light.enabled = false;
        }

        foreach(Renderer child in childRenderers)
        {
            child.enabled = false;
        }
        collider.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
