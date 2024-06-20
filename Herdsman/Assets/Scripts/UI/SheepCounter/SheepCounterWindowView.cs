using Abstractions.MVC;
using TMPro;
using UnityEngine;

namespace UI.SheepCounter
{
    public class SheepCounterWindowView : ViewBase<SheepCounterWindowModel>
    {
        [SerializeField] private TextMeshProUGUI counterText;

        public void UpdateCounter(int newCount)
        {
            counterText.text = newCount.ToString();
        }
    }
}

