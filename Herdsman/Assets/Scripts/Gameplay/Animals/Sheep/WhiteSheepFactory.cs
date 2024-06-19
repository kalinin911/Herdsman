using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public class WhiteSheepFactory : ISheepFactory
    {
        private readonly GameObject _sheepPrefab;

        public WhiteSheepFactory(GameObject sheepPrefab)
        {
            _sheepPrefab = sheepPrefab;
        }

        public SheepBase CreateSheep(Vector3 spawnPoint, Transform playerTransform, SheepManager manager)
        {
            GameObject sheepObject = Object.Instantiate(_sheepPrefab, spawnPoint, Quaternion.identity);
            WhiteSheep sheep = sheepObject.GetComponent<WhiteSheep>();
            sheep.SetPlayerTransform(playerTransform);
            sheep.SheepManager = manager;
            sheep.SetPatrolPoints();
            return sheep;
        }
    }
}
