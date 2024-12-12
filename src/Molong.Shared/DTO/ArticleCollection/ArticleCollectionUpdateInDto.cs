namespace Molong.Shared.DTO.ArticleCollection;

/// <summary>
/// 文章收藏
/// </summary>
public class ArticleCollectionUpdateInDto : UpdateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public Guid UserId { get; set; }
}

