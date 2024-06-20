using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public class WhiteSheepFactory : ISheepFactory
    {
        public WhiteSheepFactory()
        {

        }

        public TSheep CreateSheep<TSheep>(TSheep sheep, Vector3 spawnPoint, Transform playerTransform, SheepManager manager) where TSheep : SheepBase
        {
            TSheep sheepObject = Object.Instantiate<TSheep>(sheep, spawnPoint, Quaternion.identity);
            sheepObject.SetPlayerTransform(playerTransform);
            sheepObject.SheepManager = manager;
            sheepObject.SetPatrolPoints();
            return sheepObject;
        }
    }
}
