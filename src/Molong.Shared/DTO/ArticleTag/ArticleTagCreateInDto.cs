namespace Molong.Shared.DTO.ArticleTag;

/// <summary>
/// 文章标签
/// </summary>
public class ArticleTagCreateInDto : DtoBase
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
    /// 标签标识
    /// </summary>
    public Guid TagId { get; set; }
}
