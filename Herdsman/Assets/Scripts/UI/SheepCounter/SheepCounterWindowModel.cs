using Abstractions.MVC;

namespace UI.SheepCounter
{
    public class SheepCounterWindowModel : IModel
    {
        public string AssetPath => "Prefabs/UI/SheepCounter";

        public int Amount { get; set; }

        public SheepCounterWindowModel(int initialAmount)
        {
            Amount = initialAmount;
        }

        public void ChangeAmount(int newAmount)
        {
            Amount = newAmount;
        }
    }
}
