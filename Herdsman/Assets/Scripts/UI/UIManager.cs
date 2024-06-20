using Gameplay.Animals.Sheep;
using UI.SheepCounter;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] SheepCounterWindowController sheepCounterController;

        private SheepManager _sheepManager;

        public void Initialize(SheepManager sheepManager)
        {
            _sheepManager = sheepManager;
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _sheepManager.OnSheepInYardChanged += sheepCounterController.ChangeAmount;
        }

        private void OnDisable()
        {
            _sheepManager.OnSheepInYardChanged -= sheepCounterController.ChangeAmount;
        }
    }
}
