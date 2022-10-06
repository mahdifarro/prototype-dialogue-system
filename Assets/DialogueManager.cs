using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Text dialogueSpeakerDisplay;
    [TextArea(3,5)]
    public string[] sentenceList;
    private int index;
    public float typingDelay;
    public Button continueButton;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
    }

    private IEnumerator TypeInDialogueBox()
    {
        string[] stringArray = sentenceList[index].Split('_');
        dialogueSpeakerDisplay.text=stringArray[0];
        sentenceList[index] = stringArray[1];
        foreach(char letter in sentenceList[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    public void CoutinueSentence()
    {
        continueButton.interactable=false;
        if (index < sentenceList.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeInDialogueBox());
        }
        else
        {
            dialogueBox.SetActive(false);
            textDisplay.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dialogueBox.SetActive(true);
            StartCoroutine(TypeInDialogueBox());
        }
        if (textDisplay.text == sentenceList[index])
        {
            continueButton.interactable = true;
        }
    }
}
