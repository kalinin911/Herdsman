using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public interface ISheepFactory
    {
        SheepBase CreateSheep(Vector3 spawnPoint, Transform playerTransform, SheepManager manager);
    }
}
