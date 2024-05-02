using IP3;
using UnityEngine;

public class StatBarFill : MonoBehaviour
{
    private StatBar m_statBar;

    private void Awake()
    {
        m_statBar = GetComponentInParent<StatBar>();
            
        m_statBar.OnStatChanged += OnStatChanged;
    }

    private void OnStatChanged(Stat _stat)
    {
        var fillPercentage = 0.0f;
        if(_stat.Max - _stat.Min > 0.001f) { fillPercentage = (_stat.StartingValue - _stat.Min) / (_stat.Max - _stat.Min); }
        
        transform.localScale = new Vector3(fillPercentage, 1.0f, 1.0f);
    }
}
