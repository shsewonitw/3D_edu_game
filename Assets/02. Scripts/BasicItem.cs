using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class BasicItem : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public int eventLevel = 0;
    //public Dialogue[] dialogue;
    //public bool isDefaultItem = false;

    public virtual void Use()
    {
        // Check the eventlevel and interactable object; 
        if (CheckUseablity())
        {
            // Use item
            Debug.Log("Using " + name);
            RemoveFromInventory();
            EventLevelManager.instance.ShowEventByLevel(eventLevel);
        }
        else
        {
            // Misuse item
            Debug.Log("Nothing happen");
            NoticeUI.instance.DisplayNotice("잘못된 사용입니다.");
            //DialogueManager.instance.StartDialogue(dialogue);
        }
    }

    bool CheckUseablity()
    {
        // check event level;
        if (EventLevelManager.instance.currentEventLevel != eventLevel) return false;

        GameObject interactingObject = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().interactingObject;

        if (!interactingObject) return false;
        int interactingObjectEventLevel = interactingObject.GetComponent<Conversation>().eventLevel;
        if (eventLevel != interactingObjectEventLevel) return false;    
        return true;
    }

    public void RemoveFromInventory()
    {
        BasicInventory.instance.Remove(this);
    }
}
