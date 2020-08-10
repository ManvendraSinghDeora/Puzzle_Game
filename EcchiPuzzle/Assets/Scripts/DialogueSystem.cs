using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text _npcName;
    public Text _dialogue;
    public GameObject _dialogueBox;

    private Queue<string> speech;
    void Start()
    {
        speech = new Queue<string>();
    }
    public void StartDialogue(Dialogues dialogues)
    {
        _dialogueBox.SetActive(true);

        speech.Clear();

        _npcName.text = dialogues._name;

        foreach (string item in dialogues._dialogue)
        {
            speech.Enqueue(item);
        }
        
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if(speech.Count == 0)
        {
            EndDialogue();
            return;
        }

        string dialogue = speech.Dequeue();

        _dialogue.text = dialogue;

        print(dialogue);

    }

    public void EndDialogue()
    {
        _dialogueBox.SetActive(false);
    }

}