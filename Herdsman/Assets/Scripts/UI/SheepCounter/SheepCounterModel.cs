﻿namespace UI.SheepCounter
{
    public class SheepCounterModel
    {
        private int _amount;

        public int Amount
        {
            get{return _amount;}
        }

        public void ChangeAmount(int newAmount)
        {
            _amount = newAmount;
        }
    }
}
