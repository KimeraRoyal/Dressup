using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    [SerializeField] private Transform m_attachmentPointsParent;

    private Dictionary<string, Transform> m_attachmentPoints;

    public Dictionary<string, Transform> AttachmentPoints => m_attachmentPoints;

    private void Awake()
    {
        m_attachmentPoints = new Dictionary<string, Transform>();
        for (var i = 0; i < m_attachmentPointsParent.childCount; i++)
        {
            var attachmentPoint = m_attachmentPointsParent.GetChild(i);
            m_attachmentPoints.Add(attachmentPoint.gameObject.name, attachmentPoint);
        }
    }
}
