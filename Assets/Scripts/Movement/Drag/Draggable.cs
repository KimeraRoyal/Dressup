using IP3.Movement;
using UnityEngine;

namespace IP3
{
    [RequireComponent(typeof(Clickable), typeof(IMover))]
    public class Draggable : MonoBehaviour
    {
        private MousePosition m_mousePosition;
        
        private Clickable m_clickable;
        private IMover m_mover;

        private void Awake()
        {
            m_mousePosition = FindObjectOfType<MousePosition>();
            
            m_clickable = GetComponent<Clickable>();
            m_mover = GetComponent<IMover>();
        }

        private void Start()
        {
            m_mousePosition.OnMouseMoved += OnMouseMoved;
        }

        private void OnMouseMoved(Vector3 _distance)
        {
            if(!m_clickable.Held) { return; }
            
            m_mover.SetTargetPosition(m_mover.GetTargetPosition() + _distance);
        }
    }
}
