using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 标签
/// </summary>
[Table("Tag")]
[Comment("标签")]
public partial class Tag : Entity
{
    /// <summary>
    /// 名称
    /// </summary>
    [Comment("名称")]
    [StringLength(200)]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 文章标签集合
    /// </summary>
    public ICollection<ArticleTag>? ArticleTags { get; set; }
}