using UnityEngine;

namespace IP3
{
    public interface IFocuser
    {
        public bool GetFocused();
        
        public void FocusOn(Vector3? _targetPosition);
    }
}
