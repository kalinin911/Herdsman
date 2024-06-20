using Gameplay.Animals.Sheep;
using Gameplay.Player;
using UI;
using UnityEngine;

namespace Gameplay.GameplayInstaller
{
    public class GameplayInstaller : MonoBehaviour
    {
        [SerializeField] SheepManager sheepManager;
        [SerializeField] PlayerController playerController;
        [SerializeField] YardController yardController;
        [SerializeField] UIManager uiController;

        private void Awake()
        {  
            sheepManager.Initialize(playerController.transform, yardController.transform);
            yardController.Initialize(sheepManager);
            uiController.Initialize(sheepManager);
        }
    }
}
