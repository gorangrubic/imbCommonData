namespace imbCommonModels.structure
{
    #region imbVeles using

    #endregion

    /// <summary>
    /// imbCollectionMeta namenska kolekcija za  node
    /// </summary>
    public class nodeCollection : imbCollectionMetaIndexed<node>
    {
        public nodeCollection() : base("name")
        {
        }
    }
}