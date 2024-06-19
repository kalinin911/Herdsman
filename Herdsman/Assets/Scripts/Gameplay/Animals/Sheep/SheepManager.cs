using Gameplay.Animals.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public class SheepManager : MonoBehaviour
    {
        public event Action OnPlayerEnteredYard;
        public event Action<int> OnSheepInYardChanged;

        [SerializeField] GameObject sheepPrefab;       
        [SerializeField] int initialSheepCount = 10;
        [SerializeField] int maxSheepCount = 20;
        [SerializeField] int maxFollowingCount = 5;
        [SerializeField] float minSpawnInterval = 1f;
        [SerializeField] float maxSpawnInterval = 10f;

        private List<SheepBase> _sheeps;
        private ISheepFactory _factory;
        private int _currentFollowingCount = 0;
        private int _sheepInYardCount = 0;
        private Coroutine _spawnCoroutine;
        private Transform _yardTransform;
        private Transform _playerTransform;
        
        public void Init(Transform playerTransform, Transform yardTransform)
        {
            _yardTransform = yardTransform;
            _playerTransform = playerTransform;
        }

        private void Start()
        {
            _factory = new WhiteSheepFactory(sheepPrefab);
            _sheeps = new List<SheepBase>();

            for (int i = 0; i < initialSheepCount; i++)
            {
                CreateNewSheep();
            }

            _spawnCoroutine = StartCoroutine(SpawnSheepRoutine());
        }

        private void OnEnable()
        {
            OnPlayerEnteredYard += HandlePlayerEnteredYard;
        }

        private void OnDisable()
        {
            OnPlayerEnteredYard -= HandlePlayerEnteredYard;
        }

        public void PlayerEnteredYard()
        {
            OnPlayerEnteredYard?.Invoke();
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

        public void IncrementSheepInYardCount()
        {
            _sheepInYardCount++;
            OnSheepInYardChanged?.Invoke(_sheepInYardCount);
        }

        private void CreateNewSheep()
        {
            if (!CanSpawnMoreSheeps())
            {
                return;
            }

            SheepBase sheepInstance = _factory.CreateSheep(GenerateNewPatrolPoint(), _playerTransform, this);
            _sheeps.Add(sheepInstance);
        }

        private Vector3 GenerateNewPatrolPoint()
        {
            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector3 randomPoint = _playerTransform.position + (Vector3)randomDirection * 10f;

            return randomPoint;
        }

        private IEnumerator SpawnSheepRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval));
                CreateNewSheep();
            }
        }

        private void HandlePlayerEnteredYard()
        {
            foreach(var sheep in _sheeps)
            {
                if(sheep.GetCurrentState() is FollowingState)
                {
                    sheep.ChangeState(new GoingToYardState(sheep, _yardTransform.position));
                }
            }
        }
    }

}
