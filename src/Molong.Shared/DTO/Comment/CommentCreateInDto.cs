namespace Molong.Shared.DTO.Comment;

/// <summary>
/// 评论
/// </summary>
public class CommentCreateInDto : CreateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime? PublishDate { get; set; }
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
}
