using AutoMapper;
using DigitalCatalog.Application.Dtos.Article;
using DigitalCatalog.Application.Dtos.Course;
using DigitalCatalog.Application.Dtos.Document;
using DigitalCatalog.Application.Dtos.Faculty;
using DigitalCatalog.Application.Dtos.Forum;
using DigitalCatalog.Application.Dtos.Group;
using DigitalCatalog.Application.Dtos.Role;
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
            CreateMap<User, AddUserDto>().ReverseMap();

            CreateMap<Score, GetAcademicRecordDto>().ReverseMap();

            CreateMap<Course, GetCourseDto>().ReverseMap();

            CreateMap<Document, CreateDocumentDto>().ReverseMap();
            CreateMap<Document, GetDocumentDto>().ReverseMap();

            CreateMap<DocumentType, GetDocumentTypeDto>().ReverseMap();

            CreateMap<Article, GetArticleDto>().ReverseMap();
            CreateMap<Article, CreateArticleDto>().ReverseMap();

            CreateMap<Comment, GetCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();

            CreateMap<Faculty, GetFacultyDto>().ReverseMap();

            CreateMap<Group, GetGroupDto>().ReverseMap();

            CreateMap<Role, GetRoleDto>().ReverseMap();
        }
    }
}
