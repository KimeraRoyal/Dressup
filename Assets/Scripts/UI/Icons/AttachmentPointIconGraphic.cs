using UnityEngine;

namespace UI.Icons
{
    public class AttachmentPointIconGraphic : MonoBehaviour
    {
        [SerializeField] private Sprite m_sprite;

        public Sprite Sprite => m_sprite;
    }
}
