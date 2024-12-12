using Microsoft.Extensions.Logging.Abstractions;
using Molong.Domain.Model;
using Molong.Shared.DTO.Article;

namespace Molong.HostApp.Services;

/// <summary>
/// 
/// </summary>
public class ArticleService : ServiceBase
{
    private readonly MolongDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ArticleService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<MolongDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ArticleCreateInDto input)
    {
        var model = Mapper.Map<Article>(input);
        
        model.Id = NewId.NextSequentialGuid();
        model.PublishDate = DateTime.Now;
        if (input.TagIds != null)
        {
            foreach (var tagId in input.TagIds)
            {
                await _dbContext.ArticleTags.AddAsync(new ArticleTag
                {
                    Id = NewId.NextSequentialGuid(),
                    TagId = tagId,
                    ArticleId = model.Id
                });
            }
        }
        await _dbContext.Articles.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ArticleUpdateInDto input)
    {
        var model = await _dbContext.Articles.Include(x=>x.ArticleTags).SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        if (input.TagIds != null)
        {
            if (model.ArticleTags != null)
            {
                _dbContext.ArticleTags.RemoveRange(model.ArticleTags.Where(t => !input.TagIds.Any(b => b == t.TagId)));
            }

            foreach (var tagId in input.TagIds.Where(t => model.ArticleTags == null || !model.ArticleTags.Any(b => b.TagId == t)))
            {
                await _dbContext.ArticleTags.AddAsync(new ArticleTag
                {
                    Id = NewId.NextSequentialGuid(),
                    TagId = tagId,
                    ArticleId = model.Id
                });
            }
        }

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(ArticleDeleteInDto input)
    {
        var model = await _dbContext.Articles.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Articles.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ArticleBatchDeleteInDto input)
    {
        var model = await _dbContext.Articles.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Articles.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<ArticleQueryOutDto>> Query(ArticleQueryInDto input)
    {
        var query = from a in _dbContext.Articles.Include(x=>x.Category).Include(x => x.ArticleTags).ThenInclude(x=>x.Tag).AsNoTracking()
                    select a;

        #region filter
        if (!string.IsNullOrWhiteSpace(input.Title))
        {
            query = query.Where(x => x.Title.Contains(input.Title));
        }
        if (input.CategoryId != null)
        {
            query = query.Where(x => x.CategoryId.Equals(input.CategoryId));
        }
        if (input.TagId!=null)
        {
            query = query.Where(x => x.ArticleTags.Where(a=>a.TagId.Equals(input.TagId)).Any());
        }
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x=>x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return new PagingOutBase<ArticleQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<IList<ArticleQueryOutDto>> TopLikes(ArticleQueryInDto input)
    {
        var query = from a in _dbContext.Articles.Include(x => x.Category).Include(x => x.ArticleTags).ThenInclude(x => x.Tag).AsNoTracking()
                    select a;

        #region filter
        if (!string.IsNullOrWhiteSpace(input.Title))
        {
            query = query.Where(x => x.Title.Contains(input.Title));
        }
        #endregion

        var items = await query
            .OrderByDescending(x => x.Likes)
            .Take(10)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ArticleQueryOutDto>>(items);

        return itemDtos;
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ArticleGetOutDto> Get(ArticleGetInDto input)
    {
        var query = from a in _dbContext.Articles.Include(x => x.ArticleTags).AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ArticleGetOutDto>(items);
    }
}
