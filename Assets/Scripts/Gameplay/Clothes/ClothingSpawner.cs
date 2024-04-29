using UnityEngine;

namespace IP3
{
    public class ClothingSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_clothes;
        
        [SerializeField] private GameObject m_clothingBasePrefab;

        private void Start()
        {
            for (var i = 0; i < m_clothes.Length; i++)
            {
                SpawnClothing(i);
            }
        }

        private void SpawnClothing(int _index)
        {
            var clothingBase = Instantiate(m_clothingBasePrefab, transform);
            var clothing = Instantiate(m_clothes[_index], clothingBase.transform);

            clothing.layer = clothingBase.layer;
        }
    }
}
