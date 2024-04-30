using System.Linq;
using IP3.Movement;
using UnityEngine;

public class ClothingAttacher : Mover
{
    private AttachmentPoint m_attachmentPoint;
    
    private Clothing m_clothing;

    [SerializeField] private float m_attachDistance = 1.0f;
    [SerializeField] private float m_movementSmoothTime = 1.0f;

    private Vector3 m_startingPosition;
    private Vector3 m_truePosition;
    private Vector3 m_attachmentPosition;

    private bool m_attach;
    private float m_attachment;
    private float m_attachmentVelocity;

    public Clothing Clothing
    {
        get => m_clothing;
        set => m_clothing = value;
    }
    
    protected override void Start()
    {
        base.Start();

        var doll = FindObjectOfType<Doll>();
        m_attachmentPoint = doll.AttachmentPoints.First(_attachmentPoint => _attachmentPoint.gameObject.name == m_clothing.AttachmentPointName);
            
        OnTargetPositionChanged += UpdatePosition;
        UpdatePosition(TargetPosition);
        m_startingPosition = TargetPosition;
    }

    private void Update()
    {
        var attachmentAmount = m_attach ? 1.0f : 0.0f;

        m_attachment = Mathf.SmoothDamp(m_attachment, attachmentAmount, ref m_attachmentVelocity, m_movementSmoothTime);
        CurrentPosition = Vector3.Lerp(m_truePosition, m_attachmentPosition, m_attachment);
    }

    private void UpdatePosition(Vector3 _targetPosition)
    {
        m_truePosition = OffsetPosition;
        
        m_attachmentPosition = m_attachmentPoint.transform.position;
        m_attach = Vector3.Distance(m_attachmentPosition, m_truePosition) < m_attachDistance;
        
        if(m_attach) { m_attachmentPoint.AttachClothing(this); }
        else { m_attachmentPoint.DetachClothing(this, false); }
    }

    public void Reset()
        => TargetPosition = m_startingPosition;
}
