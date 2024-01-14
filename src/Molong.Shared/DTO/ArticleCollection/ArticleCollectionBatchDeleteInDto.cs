namespace Molong.Shared.DTO.ArticleCollection;

/// <summary>
/// 文章收藏
/// </summary>
public class ArticleCollectionBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

