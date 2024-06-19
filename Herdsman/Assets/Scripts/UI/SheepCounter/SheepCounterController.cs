using UnityEngine;

namespace UI.SheepCounter
{
    public class SheepCounterController : MonoBehaviour
    {
        private SheepCounterModel _model;
        private SheepCounterView _view;

        private void Start()
        {
            _model = new SheepCounterModel();
            _view = GetComponent<SheepCounterView>();
            _view.UpdateCounter(_model.Amount);
        }

        public void ChangeAmount(int newAmount)
        {
            _model.ChangeAmount(newAmount);
            _view.UpdateCounter(_model.Amount);
        }

    }
}
