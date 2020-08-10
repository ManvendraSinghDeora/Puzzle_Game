using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogues dialogues;

    public void Trigger() // Dialogue trigger
    {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogues);
    }
}
