namespace Molong.Shared.DTO.Article;

/// <summary>
/// 文章
/// </summary>
public class ArticleBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

