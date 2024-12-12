using Molong.Shared.DTO.ArticleTag;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class ArticleTagService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleTagService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ArticleTagCreateInDto input)
    {
        var model = Mapper.Map<ArticleTag>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.ArticleTags.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ArticleTagUpdateInDto input)
    {
        var model = await _dbContext.ArticleTags.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(ArticleTagDeleteInDto input)
    {
        var model = await _dbContext.ArticleTags.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ArticleTags.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ArticleTagBatchDeleteInDto input)
    {
        var model = await _dbContext.ArticleTags.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ArticleTags.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<ArticleTagQueryOutDto>> Query(ArticleTagQueryInDto input)
    {
        var query = from a in _dbContext.ArticleTags.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleTagQueryOutDto>>(items);

        return new PagingOutBase<ArticleTagQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleTagGetOutDto> Get(ArticleTagGetInDto input)
    {
        var query = from a in _dbContext.ArticleTags.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleTagGetOutDto>(items);
    }
}
