using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Entities
{
    /// <summary>
    /// Sets the entities's sorting order according to Y position.
    /// </summary>
    public class EntitySpritesSetter : MonoBehaviour
    {
        [SerializeField] private List<EntityRenderer> entityRenderers;

        void Update()
        {
            foreach(EntityRenderer entityRenderer in entityRenderers)
                entityRenderer.SpriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 300 + entityRenderer.Modifier);
        }
    }

    /// <summary>
    /// Holds the body part's sprite renderer with a modifier, to make each one in their correct position.
    /// </summary>
    [System.Serializable]
    public class EntityRenderer
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int modifier;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public int Modifier => modifier;
    }
}
