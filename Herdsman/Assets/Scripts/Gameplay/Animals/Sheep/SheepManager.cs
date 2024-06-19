using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public class SheepManager : MonoBehaviour
    {
        [SerializeField] GameObject sheepPrefab;
        [SerializeField] Transform playerTransform;
        [SerializeField] int initialSheepCount = 10;
        [SerializeField] int maxSheepCount = 20;
        [SerializeField] int maxFollowingCount = 5;
        [SerializeField] float sheepSpawnInterval = 10f;

        private List<SheepBase> _sheeps;
        private ISheepFactory _factory;
        private int _currentFollowingCount = 0;

        private void Start()
        {
            _factory = new WhiteSheepFactory(sheepPrefab);
            _sheeps = new List<SheepBase>();

            for (int i = 0; i < initialSheepCount; i++)
            {
                CreateNewSheep();
            }
        }


        public bool CanFollowPlayer()
        {
            return _currentFollowingCount < maxFollowingCount;
        }

        public bool CanSpawnMoreSheeps()
        {
            return _sheeps.Count < maxSheepCount;
        }

        public void IncrementFollowingCount()
        {
            _currentFollowingCount++;
        }

        public void DecrementFollowingCount()
        {
            _currentFollowingCount--;
        }

        private void CreateNewSheep()
        {
            if (!CanSpawnMoreSheeps())
            {
                return;
            }

            SheepBase sheepInstance = _factory.CreateSheep(GenerateNewPatrolPoint(), playerTransform, this);
            _sheeps.Add(sheepInstance);
        }

        private Vector3 GenerateNewPatrolPoint()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 randomPoint = playerTransform.position + (Vector3)randomDirection * 10f;

            return randomPoint;
        }
    }

}
