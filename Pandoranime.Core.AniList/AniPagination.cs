namespace Pandoranime.Core.AniList;

public class AniPagination<T>
{

    public int CurrentPageIndex { get; }
    public int LastPageIndex { get; }
    public bool HasNextPage { get; }
    public T[] Data { get; }

    internal AniPagination(PageInfo info, T[] data)
    {
        CurrentPageIndex = info.CurrentPageIndex;
        LastPageIndex = info.LastPageIndex;
        HasNextPage = info.HasNextPage;
        Data = data;
    }

}