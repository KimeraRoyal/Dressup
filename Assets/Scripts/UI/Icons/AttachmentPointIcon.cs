using UnityEngine;
using UnityEngine.UI;

public class AttachmentPointIcon : MonoBehaviour
{
    [SerializeField] private Image m_icon;

    public void LinkToPoint(AttachmentPoint _attachmentPoint)
    {
        ChangeIconGraphic(_attachmentPoint.GetComponent<AttachmentPointIconGraphic>());
    }

    private void ChangeIconGraphic(AttachmentPointIconGraphic _graphic)
    {
        if(!_graphic) { return; }
        m_icon.sprite = _graphic.Sprite;
    }
}
