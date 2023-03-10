using UnityEngine;

namespace CustomTools
{
    public class Test : MonoBehaviour
    {
        [Button]
        private void Test1() { Debug.Log("woah");}
        
        [Button("Testeee")]
        private void Test2(int fuck) { Debug.Log("thuurh");}
    }
}
