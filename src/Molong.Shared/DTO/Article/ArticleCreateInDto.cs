namespace Molong.Shared.DTO.Article;

/// <summary>
/// 文章
/// </summary>
public class ArticleCreateInDto : CreateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// 分类标识
    /// </summary>
    public Guid CategoryId { get; set; }
    /// <summary>
    /// 标签标识集合
    /// </summary>
    public IList<Guid>? TagIds { get; set; }
}
