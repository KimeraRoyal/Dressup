using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace IP3
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private string m_name = "Stat";
        
        [SerializeField] private float m_startingValue;
        
        [SerializeField] private float m_min;
        [SerializeField] private float m_max = 1.0f;
        [FormerlySerializedAs("m_rangeFormatting")] [SerializeField] private string m_minFormatting = "{0}";
        [SerializeField] private string m_maxFormatting = "{0}";

        public string Name => m_name;

        public float StartingValue => m_startingValue;

        public float Min => m_min;
        public float Max => m_max;

        public string MinFormatting => m_minFormatting;
        public string MaxFormatting => m_maxFormatting;
    }
}
