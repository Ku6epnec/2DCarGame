using System;
using System.Collections.Generic;
using Company.Project.Features.Inventory;
using Company.Project.Features.Items;
using JetBrains.Annotations;


namespace Company.Project.Features.Shed
{
    public class ShedController : BaseController, IShedController
    {
        #region Fields

        private readonly IUpgradable _upgradable;
        
        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IInventoryController _inventoryController;

        #endregion

        #region Life cycle

        public ShedController(
            [NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository,
            [NotNull] IInventoryController inventoryController,
            [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository 
                = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));
            
            _inventoryController 
                =  inventoryController ?? throw new ArgumentNullException(nameof(inventoryController));;
            
            _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));
        }

        #endregion
        
        #region Methods
        
        private void UpgradeCarWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<IItem> equippedItems, 
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradable);
                }
            }
        }

        #endregion
        
        #region IShedController

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
        }
        
        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _upgradable, _inventoryController.GetEquippedItems(), _upgradeHandlersRepository.Collection);
        }

        #endregion
    }
}