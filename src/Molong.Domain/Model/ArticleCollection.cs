using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 文章收藏
/// </summary>
[Table("ArticleCollection")]
[Comment("文章收藏")]
public partial class ArticleCollection : Entity
{
    /// <summary>
    /// 文章标识
    /// </summary>
    [Comment("文章标识")]
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    [Comment("用户标识")]
    public Guid UserId { get; set; }
}