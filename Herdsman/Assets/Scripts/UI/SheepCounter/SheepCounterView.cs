using TMPro;
using UnityEngine;

namespace UI.SheepCounter
{
    public class SheepCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;

        public void UpdateCounter(int newCount)
        {
            counterText.text = newCount.ToString();
        }
    }
}

