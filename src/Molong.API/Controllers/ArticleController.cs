using Molong.HostApp.Services;
using Molong.Shared.DTO.Article;

namespace Molong.HostApp.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Blogs")]
public class ArticleController : AppControllerBase
{
    private readonly ArticleService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public ArticleController(IServiceProvider serviceProvider, ArticleService service) :
        base(serviceProvider)
    {
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(ArticleCreateInDto input)
    {
        var result = await _service.Create(input);
        return Success(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Update(ArticleUpdateInDto input)
    {
        var result = await _service.Update(input);
        return Success(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Delete(ArticleDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> BatchDelete(ArticleBatchDeleteInDto input)
    {
        var result = await _service.BatchDelete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOutBase<ArticleQueryOutDto>>> Query([FromQuery] ArticleQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<IList<ArticleQueryOutDto>>> TopLikes([FromQuery] ArticleQueryInDto input)
    {
        var result = await _service.TopLikes(input);
        return Success(result);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<ArticleGetOutDto>> Get([FromQuery] ArticleGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}