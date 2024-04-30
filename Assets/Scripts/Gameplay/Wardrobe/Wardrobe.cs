using System;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    private bool m_open;

    public Action OnOpened;
    public Action OnClosed;
    
    public bool Open
    {
        get => m_open;
        set
        {
            if(m_open == value) { return; }

            m_open = value;
            if(m_open) { OnOpened?.Invoke(); }
            else { OnClosed?.Invoke(); }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Open = !Open;
        }
    }
}
