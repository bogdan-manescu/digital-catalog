using AutoMapper;
using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Dtos.Course;
using DigitalCatalog.Application.Dtos.Document;
using DigitalCatalog.Application.Dtos.Score;
using DigitalCatalog.Application.Dtos.User;
using DigitalCatalog.Domain.Models;

namespace DigitalCatalog.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, UpdateProfileDto>().ReverseMap();
            CreateMap<User, GetUserProfileDto>().ReverseMap();
            CreateMap<User, UpdateLoginCredentialsDto>().ReverseMap();

            CreateMap<Score, GetAcademicRecordDto>().ReverseMap();

            CreateMap<Course, GetCourseDto>().ReverseMap();

            CreateMap<Document, CreateDocumentDto>().ReverseMap();
            CreateMap<Document, GetDocumentDto>().ReverseMap();

            CreateMap<DocumentType, GetDocumentTypeDto>().ReverseMap();

            CreateMap<Article, GetArticleDto>().ReverseMap();
            CreateMap<Article, CreateArticleDto>().ReverseMap();
        }
    }
}
