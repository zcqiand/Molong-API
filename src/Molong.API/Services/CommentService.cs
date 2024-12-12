using Molong.Shared.DTO.Comment;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class CommentService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public CommentService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(CommentCreateInDto input)
    {
        var model = Mapper.Map<Comment>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Comments.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(CommentUpdateInDto input)
    {
        var model = await _dbContext.Comments.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(CommentDeleteInDto input)
    {
        var model = await _dbContext.Comments.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Comments.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(CommentBatchDeleteInDto input)
    {
        var model = await _dbContext.Comments.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Comments.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<CommentQueryOutDto>> Query(CommentQueryInDto input)
    {
        var query = from a in _dbContext.Comments.Include(x=>x.Article).AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<CommentQueryOutDto>>(items);

        return new PagingOutBase<CommentQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CommentGetOutDto> Get(CommentGetInDto input)
    {
        var query = from a in _dbContext.Comments.AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<CommentGetOutDto>(items);
    }
}
