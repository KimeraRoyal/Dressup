using IP3.Movement;
using UnityEngine;

public class ClothingAttacher : Mover
{
    private Transform m_attachmentPoint;
    
    private Clothing m_clothing;

    [SerializeField] private float m_attachDistance = 1.0f;

    private Vector3 m_truePosition;

    public Clothing Clothing
    {
        get => m_clothing;
        set => m_clothing = value;
    }
    
    protected override void Start()
    {
        base.Start();

        var doll = FindObjectOfType<Doll>();
        m_attachmentPoint = doll.AttachmentPoints[m_clothing.AttachmentPointName];
            
        OnTargetPositionChanged += UpdatePosition;
    }

    private void UpdatePosition(Vector3 _targetPosition)
    {
        m_truePosition = OffsetPosition;
        var attachmentPointDistance = m_attachmentPoint.transform.position;
        
        var distance = Vector3.Distance(attachmentPointDistance, m_truePosition);
        if (distance < m_attachDistance)
        {
            CurrentPosition = attachmentPointDistance;
        }
        else
        {
            CurrentPosition = m_truePosition;
        }
    }
}
