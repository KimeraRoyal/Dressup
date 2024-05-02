using UnityEngine;

namespace IP3
{
    public class ClothingSpawner : MonoBehaviour
    {
        [SerializeField] private Clothing[] m_clothingPrefabs;

        private Clothing[] m_clothes;

        private void Start()
        {
            m_clothes = new Clothing[m_clothingPrefabs.Length];
            for (var i = 0; i < m_clothes.Length; i++)
            {
                m_clothes[i] = Instantiate(m_clothingPrefabs[i], transform);
            }
        }
    }
}
