using Gameplay.Animals.Sheep;
using UI.SheepCounter;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] SheepCounterController sheepCounterController;

        private SheepManager _sheepManager;

        public void Init(SheepManager sheepManager)
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
