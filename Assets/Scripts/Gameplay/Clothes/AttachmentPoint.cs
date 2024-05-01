using System;
using UnityEngine;

public class AttachmentPoint : MonoBehaviour
{
    [SerializeField] private ClothingAttacher m_attachedClothing;

    public Action<ClothingAttacher> OnClothingAttached;
    public Action<ClothingAttacher> OnClothingDetached;

    public void AttachClothing(ClothingAttacher _clothing)
    {
        if(m_attachedClothing == _clothing) { return; }

        DetachClothing(m_attachedClothing, true);
        m_attachedClothing = _clothing;
        
        OnClothingAttached?.Invoke(_clothing);
    }

    public void DetachClothing(ClothingAttacher _clothing, bool _reset)
    {
        if(!m_attachedClothing || m_attachedClothing != _clothing) { return; }

        m_attachedClothing = null;
        if(_reset) { _clothing.Reset(); }
        else { OnClothingDetached?.Invoke(_clothing); }
    }
}
