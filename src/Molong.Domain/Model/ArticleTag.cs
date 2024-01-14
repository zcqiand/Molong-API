using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 文章标签
/// </summary>
[Table("ArticleTag")]
[Comment("文章标签")]
public partial class ArticleTag : Entity
{
    /// <summary>
    /// 文章标识
    /// </summary>
    [Comment("文章标识")]
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 文章
    /// </summary>
    public Article Article { get; set; } = null!;
    /// <summary>
    /// 标签标识
    /// </summary>
    [Comment("标签标识")]
    public Guid TagId { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public Tag Tag { get; set; } = null!;
}