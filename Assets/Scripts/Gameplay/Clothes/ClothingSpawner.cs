using System;
using UnityEngine;

namespace IP3
{
    public class ClothingSpawner : MonoBehaviour
    {
        [SerializeField] private Clothing[] m_clothes;
        
        [SerializeField] private ClothingAttacher m_clothingBasePrefab;

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

            clothing.gameObject.layer = clothingBase.gameObject.layer;
            clothingBase.Clothing = clothing;
        }
    }
}
