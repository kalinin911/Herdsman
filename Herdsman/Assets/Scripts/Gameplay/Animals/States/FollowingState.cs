﻿using Gameplay.Animals.Sheep;
using System;

namespace Gameplay.Animals.States
{
    public class FollowingState : INPCState
    {
        private readonly SheepBase _sheep;
        
        public FollowingState(SheepBase sheep)
        {
            _sheep = sheep;
        }

        public void Enter()
        {
            Console.WriteLine("Entering following state");
        }

        public void Execute()
        {
            if (!_sheep.ReachedPlayer())
            {
                _sheep.FollowPlayer();
            }  
        }

        public void Exit()
        {
            Console.WriteLine("Exiting following state");
        }
    }
}