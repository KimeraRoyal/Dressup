using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    private AttachmentPoint[] m_attachmentPoints;

    public AttachmentPoint[] AttachmentPoints => m_attachmentPoints;

    private void Awake()
    {
        m_attachmentPoints = GetComponentsInChildren<AttachmentPoint>();
    }
}
