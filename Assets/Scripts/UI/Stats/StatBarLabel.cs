using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace IP3
{
    [RequireComponent(typeof(TMP_Text))]
    public class StatBarLabel : MonoBehaviour
    {
        private enum LabelType
        {
            Text,
            MinBound,
            MaxBound
        }
        
        private StatBar m_statBar;

        private TMP_Text m_text;

        [SerializeField] private LabelType m_type;

        private void Awake()
        {
            m_statBar = GetComponentInParent<StatBar>();

            m_text = GetComponent<TMP_Text>();
            
            m_statBar.OnStatChanged += OnStatChanged;
        }

        private void OnStatChanged(Stat _stat)
            => m_text.text = m_type switch
            {
                LabelType.Text => _stat.Name,
                LabelType.MinBound => string.Format(_stat.MinFormatting, _stat.Min),
                LabelType.MaxBound => string.Format(_stat.MaxFormatting, _stat.Max),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}
