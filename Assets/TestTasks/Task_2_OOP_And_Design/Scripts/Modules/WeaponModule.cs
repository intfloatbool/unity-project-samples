using TestTasks.Task_2_OOP_And_Design.Scripts.Targeting;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules
{
    public class WeaponModule : ModuleBase
    {
        public float BaseDelay { get; private set; }
        public int BaseDamage { get; private set; }
        public float CurrentDelay { get; set; }
        public int CurrentDamage { get; set; }
        
        private ITargetable _currentTarget = new NullTargetable();

        private float _autoshootTimer;
        private Vector3 _weaponSourcePosition;

        public WeaponModule(float baseDelay, int baseDamage)
        {
            CurrentDelay = baseDelay;
            CurrentDamage = baseDamage;

            BaseDelay = baseDelay;
            BaseDamage = baseDamage;
        }

        public void SetTarget(ITargetable targetable)
        {
            _currentTarget = targetable;
        }

        public void SetSourcePosition(Vector3 weaponSourcePos)
        {
            _weaponSourcePosition = weaponSourcePos;
        }
        

        public override void OnStart()
        {
            
        }

        public override void OnStop()
        {
            
        }

        public override void OnFrame()
        {
            HandleShootLoop();
        }

        private void HandleShootLoop()
        {
            if (_autoshootTimer > CurrentDelay)
            {
                Shoot();
                _autoshootTimer = 0f;
            }
            
            _autoshootTimer += Time.deltaTime;
        }

        private void Shoot()
        {
            if(!_currentTarget.CurrentPosition.HasValue)
                return;
            
            bool isTargetFound = false;
            var direction = (_currentTarget.CurrentPosition.Value - _weaponSourcePosition).normalized;
            if (Physics.Raycast(_weaponSourcePosition, direction, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ReceiveDamage(CurrentDamage);
                    isTargetFound = true;
                }
                
            }
            
            /*Debug.Log($"Shoot! isTargetFound: " + isTargetFound);*/
        }
    }
}