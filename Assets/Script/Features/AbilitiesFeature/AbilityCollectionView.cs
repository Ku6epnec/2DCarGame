using System;
using System.Collections.Generic;
using Company.Project.Features.Items;
using UnityEngine;


namespace Company.Project.Features.Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        #region Fields
        
        private IReadOnlyList<IItem> _abilityItems;

        #endregion

        #region OtherMethods
        
        protected virtual void OnUseRequested(IItem e)
        {
            UseRequested?.Invoke(this, e);
        }

        #endregion

        #region IAbilityCollectionView

        public event EventHandler<IItem> UseRequested;
        
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            _abilityItems = abilityItems;
        }

        public void Show()
        {

        }

        public void Hide()
        {

        }

        #endregion
    }
}