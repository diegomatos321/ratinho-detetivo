using UnityEngine.UI;
using TMPro;
using UnityEngine;

public sealed class DialogueManager : MonoBehaviour {
  [SerializeField] private Canvas UIContainer;
  [SerializeField] private TextMeshProUGUI characterNameComponent;
  [SerializeField] private TextMeshProUGUI messageComponent;
  [SerializeField] private Image avatarComponent;

  public static DialogueManager Instance {
    get; private set;
  }
  
  [SerializeField] private DialogueTemplate currentDialogue;
  private bool hasStarted = false, isPlaying = false;

  private void Awake() {
    if (Instance != null && Instance != this) { 
      Destroy(this.gameObject);
    } else {
      Instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
  }

  private void Start() {
    // HideUI();
    startDialogue();
  }

  private void Update() {
    /* if(keyDown && hasStarted) {

    } */
  }

  public void startDialogue(/* DialogueTemplate dialogueToPlay */) {
    // currentDialogue = dialogueToPlay;
    hasStarted = true;
    setUIInfo();
    showDialogueUI();
    showDialogueMessage();
  }

  private void setUIInfo() {
    characterNameComponent.SetText(currentDialogue.personagem.Nome);
    avatarComponent.sprite = currentDialogue.personagem.Avatar;
  }

  private void showDialogueUI() {
    UIContainer.enabled = true;
  }

  private void HideUI() {
    UIContainer.enabled = false;
  }

  private void showDialogueMessage() {
    messageComponent.text = currentDialogue.texto;
  }
}
