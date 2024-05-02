using System.Linq;
using IP3;
using IP3.Movement;
using UnityEngine;

public class ClothingAttacher : Mover
{
    private AttachmentPoint m_attachmentPoint;

    private Clickable m_clickable;
    private Clothing m_clothing;

    [SerializeField] private float m_attachDistance = 1.0f;
    [SerializeField] private float m_movementSmoothTime = 1.0f;

    private Vector3 m_startingPosition;
    private Vector3 m_truePosition;
    private Vector3 m_attachmentPosition;

    private bool m_attach;
    private float m_attachment;
    private float m_attachmentVelocity;

    protected override void Awake()
    {
        base.Awake();

        m_clickable = GetComponent<Clickable>();
        m_clothing = GetComponent<Clothing>();
    }

    protected override void Start()
    {
        base.Start();

        var doll = FindObjectOfType<Doll>();
        m_attachmentPoint = doll.AttachmentPoints.First(_attachmentPoint => _attachmentPoint.gameObject.name == m_clothing.AttachmentPointName);
            
        OnTargetPositionChanged += UpdatePosition;
        UpdatePosition(TargetPosition);
        m_startingPosition = TargetPosition;
        
        m_clickable.OnReleased += OnReleased;
    }

    private void Update()
    {
        var attachmentAmount = m_attach ? 1.0f : 0.0f;

        m_attachment = Mathf.SmoothDamp(m_attachment, attachmentAmount, ref m_attachmentVelocity, m_movementSmoothTime);
        
        var position = Vector3.Lerp(m_truePosition, m_attachmentPosition, m_attachment);
        position.z = m_clickable.Held ? -1 : 0;
        CurrentPosition = position;
    }

    private void UpdatePosition(Vector3 _targetPosition)
    {
        m_truePosition = OffsetPosition;
        
        m_attachmentPosition = m_attachmentPoint.transform.position;
        m_attach = Vector3.Distance(m_attachmentPosition, m_truePosition) < m_attachDistance;
        
        if(!m_attach) { m_attachmentPoint.DetachClothing(this, false); }
    }

    private void OnReleased()
    {
        if(m_attach) { m_attachmentPoint.AttachClothing(this); }
    }

    public void Reset()
        => TargetPosition = m_startingPosition;
}
