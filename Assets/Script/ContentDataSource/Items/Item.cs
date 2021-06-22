using Company.Project.Features.Items;


namespace Company.Project.Content
{
    public class Item : IItem
    {
        #region Fields

        public int Id { get; set; }
        public ItemInfo Info { get; set; }

        #endregion
    }
}