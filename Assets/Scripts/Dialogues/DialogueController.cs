using Febucci.UI;
using FMODUnity;
using PocketPeople.UI;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace PocketPeople.Dialogues
{
    /// <summary>
    /// Controls the exhibition of the dialogue messages.
    /// </summary>
    public class DialogueController : BasicWindow
    {
        public static event Action OnEndDialogue = delegate { };

        [SerializeField, FoldoutGroup("References")] private TextAnimatorPlayer sentencePlayer;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI sentence;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI speaker;
        [SerializeField, FoldoutGroup("Sounds")] private EventReference openDialogue;
        [SerializeField, FoldoutGroup("Sounds")] private EventReference closeDialogue;
        [SerializeField, FoldoutGroup("Sounds")] private EventReference typewriter;
        private static Action<Dialogue> OnShowMessage = delegate { };

        private List<DialogueMessage> messages;
        private int index;
        private bool isTyping;

        private void Awake()
        {
            OnShowMessage += Show;
            sentencePlayer.onTypewriterStart.AddListener(OnTypewriterStart);
            sentencePlayer.onTextShowed.AddListener(OnTypewriterStop);
            sentencePlayer.onCharacterVisible.AddListener(OnType);
        }
        private void OnDestroy()
        {
            OnShowMessage -= Show;
            sentencePlayer.onTypewriterStart.RemoveListener(OnTypewriterStart);
            sentencePlayer.onTextShowed.RemoveListener(OnTypewriterStop);
            sentencePlayer.onCharacterVisible.RemoveListener(OnType);
        }
        [Button("test")]    //TODO: remove
        public static void ShowDialogue(Dialogue dialogue) => OnShowMessage(dialogue);

        public void FirstMessage()
        {
            isTyping = true;
            sentence.text = messages[index].Sentence;
        }

        public void NextMessage()
        {
            if (isTyping)
            {
                sentencePlayer.SkipTypewriter();
                return;
            }

            index++;
            if (index < messages.Count)
                sentence.text = messages[index].Sentence;
            else
            {
                RuntimeManager.PlayOneShot(closeDialogue);
                OnEndDialogue();
                ToggleWindow();
            }
        }

        private void Show(Dialogue dialogue)
        {
            if (isOpening)
                return;

            RuntimeManager.PlayOneShot(openDialogue);
            index = 0;
            messages = dialogue.Messages;
            speaker.text = messages[index].Speaker;
            sentence.text = "";

            ToggleWindow();
        }

        private void OnTypewriterStart() => isTyping = true;
        private void OnTypewriterStop() => isTyping = false;
        private void OnType(char letter) => RuntimeManager.PlayOneShot(typewriter);
    }
}
