using System.Collections;
using UnityEngine;
using TMPro;

public class reydialogo : MonoBehaviour
{

private bool isPlayerInRange;
private bool didDialogueStart;
    private int lineIndex; 

    [SerializeField] private GameObject DialogueMark;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField, TextArea (6, 10)] private TMP_Text DialogueText;
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
        
        }
    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        lineIndex = 0;
        lineIndex = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            isPlayerInRange = true;
            DialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            DialogueMark.SetActive(false);
        }
    }
}
