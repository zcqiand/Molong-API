using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 文章
/// </summary>
[Table("Article")]
[Comment("文章")]
public partial class Article : Entity
{
    /// <summary>
    /// 标题
    /// </summary>
    [Comment("标题")]
    [StringLength(200)]
    public string Title { get; set; } = null!;
    /// <summary>
    /// 内容
    /// </summary>
    [Comment("内容")]
    public string Content { get; set; } = null!;
    /// <summary>
    /// 点赞数
    /// </summary>
    [Comment("点赞数")]
    public int Likes { get; set; }
    /// <summary>
    /// 收藏数
    /// </summary>
    [Comment("收藏数")]
    public int Collections { get; set; }
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
    /// 分类标识
    /// </summary>
    [Comment("分类标识")]
    public Guid CategoryId { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    public Category Category { get; set; } = null!;
    /// <summary>
    /// 文章评论集合
    /// </summary>
    public ICollection<Comment>? Comments { get; set; }
    /// <summary>
    /// 文章标签集合
    /// </summary>
    public ICollection<ArticleTag>? ArticleTags { get; set; }

}