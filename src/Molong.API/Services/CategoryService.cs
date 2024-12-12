using Molong.Shared.DTO.Category;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class CategoryService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public CategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(CategoryCreateInDto input)
    {
        var model = Mapper.Map<Category>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Categories.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(CategoryUpdateInDto input)
    {
        var model = await _dbContext.Categories.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(CategoryDeleteInDto input)
    {
        var model = await _dbContext.Categories.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Categories.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(CategoryBatchDeleteInDto input)
    {
        var model = await _dbContext.Categories.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Categories.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<CategoryQueryOutDto>> Query(CategoryQueryInDto input)
    {
        var query = from a in _dbContext.Categories.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<CategoryQueryOutDto>>(items);

        return new PagingOutBase<CategoryQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<CategoryQueryOutDto>> QueryAll(CategoryQueryInDto input)
    {
        var query = from a in _dbContext.Categories.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<CategoryQueryOutDto>>(items);

        return itemDtos;
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CategoryGetOutDto> Get(CategoryGetInDto input)
    {
        var query = from a in _dbContext.Categories.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<CategoryGetOutDto>(items);
    }
}
