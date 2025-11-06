using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Playables;

public class DialogueController : MonoBehaviour
{
    [System.Serializable]
    public class DialogueBlock
    {
        [TextArea(2, 5)]
        public string[] lines;
    }

    [Header("Referencias")]
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textComponent;
    public PlayableDirector timelineDirector;

    [Header("Diálogos")]
    public DialogueBlock[] dialogues; // ← Aquí tendrás varios “bloques de diálogo”
    public float textSpeed = 0.05f;

    private int currentDialogueIndex = 0;
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    void Start()
    {
        textComponent.text = string.Empty;
        if (dialogueCanvas) dialogueCanvas.SetActive(false);
    }

    void Update()
    {
        if (!isDialogueActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogues[currentDialogueIndex].lines[currentLineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogues[currentDialogueIndex].lines[currentLineIndex];
            }
        }
    }

    public void StartDialogue(int dialogueIndex)
    {
        if (dialogueIndex < 0 || dialogueIndex >= dialogues.Length)
        {
            Debug.LogWarning("Índice de diálogo fuera de rango");
            return;
        }

        currentDialogueIndex = dialogueIndex;
        currentLineIndex = 0;
        dialogueCanvas.SetActive(true);
        textComponent.text = string.Empty;
        isDialogueActive = true;

        if (timelineDirector != null)
        {
            timelineDirector.Pause();
            Debug.Log("Timeline pausada mientras aparece el diálogo.");
        }

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogues[currentDialogueIndex].lines[currentLineIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (currentLineIndex < dialogues[currentDialogueIndex].lines.Length - 1)
        {
            currentLineIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueCanvas.SetActive(false);

        if (timelineDirector != null)
        {
            timelineDirector.Resume();
            Debug.Log("Timeline reanudada después del diálogo.");
        }
    }
}
