namespace Molong.Shared.DTO.ArticleTag;

/// <summary>
/// 文章标签
/// </summary>
public class ArticleTagBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

