using JetBrains.Annotations;
using Company.Project.Content;
using UnityEngine;


namespace Company.Project.Features.Abilities
{
    public class SmokeAbility : IAbility
    {
        #region Fields

        private readonly AbilityItemConfig _config;

        #endregion


        #region OtherMethods

        public SmokeAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.view).GetComponent<Rigidbody2D>();
            projectile.AddForce(-activator.GetViewObject().transform.right * _config.value, ForceMode2D.Force);
        }

        #endregion
    }
}
