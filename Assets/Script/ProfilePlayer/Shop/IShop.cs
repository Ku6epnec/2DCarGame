using Tools;


namespace Profile.Shop
{
    public interface IShop
    {
        #region Fields

        string GetCost(string productID);

        IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        IReadOnlySubscriptionAction OnFailedPurchase { get; }

        void Buy(string id);
        void RestorePurchase();

        #endregion
    }
}

