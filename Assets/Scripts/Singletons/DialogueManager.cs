using UnityEngine.UI;
using TMPro;
using UnityEngine;

public sealed class DialogueManager : MonoBehaviour {
  [SerializeField] private Canvas UIContainer;
  [SerializeField] private TextMeshProUGUI characterNameComponent;
  [SerializeField] private TextMeshProUGUI messageComponent;
  [SerializeField] private Image avatarComponent;
  [SerializeField] private DialogueTemplate currentDialogue;

  public static DialogueManager Instance {
    get; private set;
  }
  public bool hasStarted {
    get; private set;
  }
  
  private void Awake() {
    if (Instance != null && Instance != this) { 
      Destroy(this.gameObject);
    } else {
      Instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
  }

  private void Start() {
    HideUI();
    // isPlaying = false;
    hasStarted = false;
  }

  public void StartDialogue(/* DialogueTemplate dialogueToPlay */) {
    // if(dialogueToPlay == null)
      // return;
    
    // currentDialogue = dialogueToPlay;
    hasStarted = true;
    setUIInfo();
    showDialogueUI();
  }

  public void NextLine() {
    if(currentDialogue.opcoes.Count > 0) {
      Debug.Log("Mostrar Opções");
    } else if (currentDialogue.proximoDialogo != null) {
      Debug.Log("Ir para o proximo Dialogo");
      currentDialogue = currentDialogue.proximoDialogo;
      setUIInfo();
    } else {
      Debug.Log("Dialogo acabou");
    }
  }

  private void setUIInfo() {
    characterNameComponent.SetText(currentDialogue.personagem.Nome);
    avatarComponent.sprite = currentDialogue.personagem.Avatar;
    messageComponent.SetText(currentDialogue.texto);
  }

  private void showDialogueUI() {
    UIContainer.enabled = true;
  }

  private void HideUI() {
    UIContainer.enabled = false;
  }
}
