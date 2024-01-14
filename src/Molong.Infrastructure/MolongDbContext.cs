using Molong.Domain.Model;

namespace Molong.Infrastructure;

public partial class MolongDbContext : DbContext
{
    public MolongDbContext(DbContextOptions<MolongDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<ArticleCollection> ArticleCollections { get; set; } = null!;
    public virtual DbSet<ArticleTag> ArticleTags { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Comment> Comments { get; set; } = null!;
    public virtual DbSet<Tag> Tags { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}