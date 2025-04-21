using EntitiesInterfaces.Base;

namespace BusinessLogicInterfaces.Commons
{
    public interface ICompletionsBL
    {
        #region Post
        IResponseDTO Post(string prompt);
        #endregion
    }
}
