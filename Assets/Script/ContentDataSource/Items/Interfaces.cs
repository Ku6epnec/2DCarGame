namespace Company.Project.Features.Items
{
    public interface IItem
    {
        #region Fields

        int Id { get; }
        ItemInfo Info { get; }

        #endregion
    }

    public struct ItemInfo
    {
        #region Fields

        public string Title { get; set; }

        #endregion
    }
}