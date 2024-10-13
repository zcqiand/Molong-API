using Molong.Domain.Model;
using Molong.Shared.DTO.Article;
using Molong.Shared.DTO.Category;
using Molong.Shared.DTO.Comment;
using Molong.Shared.DTO.Tag;

namespace Molong.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region Map
        CreateMap<Category, CategoryGetOutDto>();
        CreateMap<Category, CategoryQueryOutDto>();
        CreateMap<CategoryCreateInDto, Category>();
        CreateMap<CategoryUpdateInDto, Category>();

        CreateMap<Article, ArticleGetOutDto>()
            .ForMember(d => d.TagIds, opt => opt.MapFrom(src => src.ArticleTags.Select(s => s.TagId)));
        CreateMap<Article, ArticleQueryOutDto>()
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(d => d.Tags, opt => opt.MapFrom(src => src.ArticleTags.Select(s=>s.Tag)));
        CreateMap<ArticleCreateInDto, Article>();
        CreateMap<ArticleUpdateInDto, Article>();

        CreateMap<Comment, CommentGetOutDto>();
        CreateMap<Comment, CommentQueryOutDto>()
            .ForMember(d => d.ArticleTitle, opt => opt.MapFrom(src => src.Article.Title));
        CreateMap<CommentCreateInDto, Comment>();
        CreateMap<CommentUpdateInDto, Comment>();

        CreateMap<Tag, TagGetOutDto>();
        CreateMap<Tag, TagQueryOutDto>();
        CreateMap<TagCreateInDto, Tag>();
        CreateMap<TagUpdateInDto, Tag>();
        #endregion
    }
}