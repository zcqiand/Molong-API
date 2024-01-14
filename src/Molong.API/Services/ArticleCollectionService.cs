using Molong.Shared.DTO.ArticleCollection;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class ArticleCollectionService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleCollectionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ArticleCollectionCreateInDto input)
    {
        var model = Mapper.Map<ArticleCollection>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.ArticleCollections.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ArticleCollectionUpdateInDto input)
    {
        var model = await _dbContext.ArticleCollections.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(ArticleCollectionDeleteInDto input)
    {
        var model = await _dbContext.ArticleCollections.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ArticleCollections.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ArticleCollectionBatchDeleteInDto input)
    {
        var model = await _dbContext.ArticleCollections.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ArticleCollections.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ArticleCollectionQueryOutDto>> Query(ArticleCollectionQueryInDto input)
    {
        var query = from a in _dbContext.ArticleCollections.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleCollectionQueryOutDto>>(items);

        return new PagingOut<ArticleCollectionQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleCollectionGetOutDto> Get(ArticleCollectionGetInDto input)
    {
        var query = from a in _dbContext.ArticleCollections.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleCollectionGetOutDto>(items);
    }
}
