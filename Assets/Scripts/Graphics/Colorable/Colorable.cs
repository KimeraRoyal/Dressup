using System;
using IP3.Graphics.Colorable;
using UnityEngine;

namespace IP3
{
    public class Colorable : MonoBehaviour, IColorable
    {
        private Color m_color;

        public Color Color
        {
            get => m_color;
            set
            {
                m_color = value;
                OnColorChanged?.Invoke(m_color);
            }
        }

        public Action<Color> OnColorChanged;

        public void SetColor(Color _color)
            => Color = _color;
    }
}
