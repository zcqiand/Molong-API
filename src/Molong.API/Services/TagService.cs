using Molong.Shared.DTO.Tag;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class TagService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public TagService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(TagCreateInDto input)
    {
        var model = Mapper.Map<Tag>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Tags.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(TagUpdateInDto input)
    {
        var model = await _dbContext.Tags.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(TagDeleteInDto input)
    {
        var model = await _dbContext.Tags.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Tags.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(TagBatchDeleteInDto input)
    {
        var model = await _dbContext.Tags.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Tags.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<TagQueryOutDto>> Query(TagQueryInDto input)
    {
        var query = from a in _dbContext.Tags.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<TagQueryOutDto>>(items);

        return new PagingOutBase<TagQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取所有清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<TagQueryOutDto>> QueryAll(TagQueryInDto input)
    {
        var query = from a in _dbContext.Tags.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<TagQueryOutDto>>(items);

        return itemDtos;
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TagGetOutDto> Get(TagGetInDto input)
    {
        var query = from a in _dbContext.Tags.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<TagGetOutDto>(items);
    }
}
