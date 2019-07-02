using UnityEngine;

public class ItemPickup : Interactable {

    public BasicItem item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
        SoundManager.instance.PlaySound("Effect_GainItem");
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        // Add to inventory
        bool wasPickUp = BasicInventory.instance.Add(item);

        if(wasPickUp)
            Destroy(gameObject);
    }
}
 