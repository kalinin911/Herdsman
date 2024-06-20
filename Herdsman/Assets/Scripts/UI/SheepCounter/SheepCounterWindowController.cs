using Abstractions.MVC;
using UnityEngine;

namespace UI.SheepCounter
{
    public class SheepCounterWindowController : ControllerBase<SheepCounterWindowModel, SheepCounterWindowView>
    {
        public SheepCounterWindowController(SheepCounterWindowModel model, Transform parent): base(model) 
        {
            View.transform.SetParent(parent);
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        public void ChangeAmount(int newAmount)
        {
            Model.ChangeAmount(newAmount);
            View.UpdateCounter(Model.Amount);
        }
    }
}
