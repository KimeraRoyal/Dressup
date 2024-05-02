using System;
using UnityEngine;

namespace IP3
{
    public class StatBar : MonoBehaviour
    {
        private Stat m_stat;

        public Stat Stat
        {
            get => m_stat;
            set
            {
                if(m_stat == value) { return; }

                m_stat = value;
                OnStatChanged?.Invoke(m_stat);
            }
        }

        public Action<Stat> OnStatChanged;
    }
}
