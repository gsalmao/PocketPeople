using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Dialogues
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private List<DialogueMessage> messages;

        public List<DialogueMessage> Messages => messages;
    }

    [System.Serializable]
    public class DialogueMessage
    {
        [SerializeField] private string speaker;
        [SerializeField, TextArea(3,3)] private string sentence;

        public string Speaker => speaker;
        public string Sentence => sentence;
    }
}
