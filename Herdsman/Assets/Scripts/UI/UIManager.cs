using Gameplay.Animals.Sheep;
using UI.SheepCounter;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Transform windowParent;

        private SheepCounterWindowController _sheepCounterController;
        private SheepManager _sheepManager;

        public void Initialize(SheepManager sheepManager)
        {
            _sheepManager = sheepManager;
            CreateNewSheepCounter();
            _sheepManager.OnSheepInYardChanged += _sheepCounterController.ChangeAmount;

        }

        private void OnDisable()
        {
            _sheepManager.OnSheepInYardChanged -= _sheepCounterController.ChangeAmount;
        }

        private void CreateNewSheepCounter()
        {
            var model = new SheepCounterWindowModel(0);
            _sheepCounterController = new SheepCounterWindowController(model, windowParent);
        }
    }
}
