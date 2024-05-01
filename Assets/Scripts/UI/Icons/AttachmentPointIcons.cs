using UnityEngine;

public class AttachmentPointIcons : MonoBehaviour
{
    [SerializeField] private AttachmentPointIcon m_iconPrefab;

    private void Start()
    {
        var doll = FindObjectOfType<Doll>();
        foreach (var attachmentPoint in doll.AttachmentPoints)
        {
            SpawnIcon(attachmentPoint);
        }
    }

    private void SpawnIcon(AttachmentPoint _attachmentPoint)
    {
        var icon = Instantiate(m_iconPrefab, transform);
        icon.LinkToPoint(_attachmentPoint);
    }
}
