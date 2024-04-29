using UnityEngine;

public class Clothing : MonoBehaviour
{
    [SerializeField] private string m_attachmentPointName;

    public string AttachmentPointName => m_attachmentPointName;
}
