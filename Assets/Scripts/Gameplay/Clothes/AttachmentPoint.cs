using UnityEngine;

public class AttachmentPoint : MonoBehaviour
{
    [SerializeField] private ClothingAttacher m_attachedClothing;

    public void AttachClothing(ClothingAttacher _clothing)
    {
        if(m_attachedClothing == _clothing) { return; }

        DetachClothing(m_attachedClothing, true);
        m_attachedClothing = _clothing;
    }

    public void DetachClothing(ClothingAttacher _clothing, bool _reset)
    {
        if(!m_attachedClothing || m_attachedClothing != _clothing) { return; }

        m_attachedClothing = null;
        if(_reset) { _clothing.Reset(); }
    }
}
