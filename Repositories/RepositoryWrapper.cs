
using Web.Entities;

namespace Web.Repositories;
public interface IRepositoryWrapper
{
    IRepositoryBase<Gift> Gifts { get; }
    IRepositoryBase<Prize> Prizes { get; }
    IRepositoryBase<PrizeItem> PrizeItems { get; }
    IRepositoryBase<Scholarship> Scholarships { get; }
    IRepositoryBase<Student> Students { get; }

    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationDbContext ApplicationDbContext;
    public RepositoryWrapper(ApplicationDbContext applicationDbContext) => ApplicationDbContext = applicationDbContext;

    private IRepositoryBase<Gift>? GiftsRepositoryBase;
    public IRepositoryBase<Gift> Gifts => GiftsRepositoryBase ??= new RepositoryBase<Gift>(ApplicationDbContext);

    private IRepositoryBase<Prize>? PrizesRepositoryBase;
    public IRepositoryBase<Prize> Prizes => PrizesRepositoryBase ??= new RepositoryBase<Prize>(ApplicationDbContext);

    private IRepositoryBase<PrizeItem>? PrizeItemsRepositoryBase;
    public IRepositoryBase<PrizeItem> PrizeItems => PrizeItemsRepositoryBase ??= new RepositoryBase<PrizeItem>(ApplicationDbContext);

    private IRepositoryBase<Scholarship>? ScholarshipsRepositoryBase;
    public IRepositoryBase<Scholarship> Scholarships => ScholarshipsRepositoryBase ??= new RepositoryBase<Scholarship>(ApplicationDbContext);


    private IRepositoryBase<Student>? StudentsRepositoryBase;
    public IRepositoryBase<Student> Students => StudentsRepositoryBase ??= new RepositoryBase<Student>(ApplicationDbContext);


    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default) => await ApplicationDbContext.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) => await ApplicationDbContext.Database.CommitTransactionAsync(cancellationToken);

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) => await ApplicationDbContext.Database.RollbackTransactionAsync(cancellationToken);
}
