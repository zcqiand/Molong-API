using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 评论
/// </summary>
[Table("Comment")]
[Comment("评论")]
public partial class Comment : Entity
{
    /// <summary>
    /// 内容
    /// </summary>
    [Comment("内容")]
    public string Content { get; set; } = null!;
    /// <summary>
    /// 发布时间
    /// </summary>
    [Comment("发布时间")]
    public DateTime? PublishDate { get; set; }
    /// <summary>
    /// 创建人标识
    /// </summary>
    [Comment("创建人标识")]
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 创建人
    /// </summary>
    [Comment("创建人")]
    [StringLength(50)]
    public string? CreateFullName { get; set; }
    /// <summary>
    /// 文章标识
    /// </summary>
    [Comment("文章标识")]
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 文章
    /// </summary>
    public Article Article { get; set; } = null!;

}