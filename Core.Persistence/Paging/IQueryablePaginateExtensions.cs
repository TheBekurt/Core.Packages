using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging;

public static class IQueryablePaginateExtensions
{
    public static async Task<Paginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default
    )

    {
        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

        var paginate = new Paginate<T>
        {
            Items = items,
            Index = index,
            Size = size,
            Count = count,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
        return paginate;
    }

    public static Paginate<T> ToPaginate<T>(
        this IQueryable<T> source,
        int index,
        int size
    )
    {
        var count = source.Count();
        var items = source.Skip(index * size).Take(size).ToList();
        var paginate = new Paginate<T>
        {
            Items = items,
            Index = index,
            Size = size,
            Count = count,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
        return paginate;
    }
}