using Molong.Shared.DTO.Category;
using Molong.Shared.DTO.Tag;

namespace Molong.Shared.DTO.Article;

/// <summary>
/// 文章
/// </summary>
public class ArticleQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// 点赞数
    /// </summary>
    public int Likes { get; set; }
    /// <summary>
    /// 收藏数
    /// </summary>
    public int Collections { get; set; }
    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime? PublishDate { get; set; }
    /// <summary>
    /// 创建人标识
    /// </summary>
    public Guid? CreateUserId { get; set; }
    /// <summary>
    /// 创建人
    /// </summary>
    public string? CreateFullName { get; set; }
    /// <summary>
    /// 分类标识
    /// </summary>
    public Guid CategoryId { get; set; }
    /// <summary>
    /// 分类名称
    /// </summary>
    public string? CategoryName { get; set; }
    /// <summary>
    /// 分类名称
    /// </summary>
    public IList<TagGetOutDto> Tags { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}

