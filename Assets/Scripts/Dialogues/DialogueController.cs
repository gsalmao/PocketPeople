using Febucci.UI;
using FMODUnity;
using PocketPeople.UI;
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

        [SerializeField] private TextAnimatorPlayer sentencePlayer;
        [SerializeField] private TextMeshProUGUI sentence;
        [SerializeField] private TextMeshProUGUI speaker;
        [SerializeField] private EventReference typewriter;
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
                OnEndDialogue();
                ToggleWindow();
            }
        }

        private void Show(Dialogue dialogue)
        {
            if (isOpening)
                return;

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
