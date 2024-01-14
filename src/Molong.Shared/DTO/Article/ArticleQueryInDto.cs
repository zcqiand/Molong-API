namespace Molong.Shared.DTO.Article;

/// <summary>
/// 文章
/// </summary>
public class ArticleQueryInDto : PagingInBase
{
    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// 类别标识
    /// </summary>
    public Guid? CategoryId { get; set; }
    /// <summary>
    /// 标签标识
    /// </summary>
    public Guid? TagId { get; set; }
}

