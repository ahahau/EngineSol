using System;
using _01.Code.Entities;
using _01.Code.Manager;
using UnityEngine;

namespace _01.Code.Enemies
{
    public class Enemy : Entities.Entity
    {
        private GameObject _lastTargetPosition; 
        private EntityHealth _health;
        private TargetChecker _targetChecker;

        protected override void Awake()
        {
            base.Awake();
            _health = GetCompo<EntityHealth>();
            _targetChecker = GetCompo<TargetChecker>();
            
            
        }

    }
}