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
        [SerializeField] UIController uiController;

        private void Awake()
        {  
            sheepManager.Init(playerController.transform, yardController.transform);
            yardController.Init(sheepManager);
            uiController.Init(sheepManager);
        }
    }
}
