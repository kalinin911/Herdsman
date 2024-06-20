using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public interface ISheepFactory
    {
        TSheep CreateSheep<TSheep>(TSheep sheep, Vector3 spawnPoint, Transform playerTransform, SheepManager manager) where TSheep : SheepBase;
    }
}
