using UnityEngine;

namespace UI.SheepCounter
{
    public class SheepCounterWindowController : MonoBehaviour
    {
        private SheepCounterWindowModel _model;
        private SheepCounterWindowView _view;

        private void Start()
        {
            _model = new SheepCounterWindowModel();
            _view = GetComponent<SheepCounterWindowView>();
            _view.UpdateCounter(_model.Amount);
        }

        public void ChangeAmount(int newAmount)
        {
            _model.ChangeAmount(newAmount);
            _view.UpdateCounter(_model.Amount);
        }

    }
}
