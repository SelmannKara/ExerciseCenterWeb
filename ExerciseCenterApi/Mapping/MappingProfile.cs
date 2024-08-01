using AutoMapper;
using ExerciseCenter_API.Dtos.BlogPostsDtos;
using ExerciseCenter_API.Dtos.ServicesDtos;
using ExerciseCenter_API.Dtos.TestimonialsDtos;
using ExerciseCenter_API.Dtos.WhoWeAreDtos;
using ExerciseCenter_API.Models.BlogPostsModels;
using ExerciseCenter_API.Models.ServicesModels;
using ExerciseCenter_API.Models.TestimonialsModels;
using ExerciseCenter_API.Models.WhoWeAreModels;

namespace ExerciseCenter_API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();


            CreateMap<WhoWeAre, ResultWhoWeAreDto>().ReverseMap();
            CreateMap<CreateWhoWeAreDto, WhoWeAre>();
            CreateMap<UpdateWhoWeAreDto, WhoWeAre>();

            CreateMap<BlogPosts, ResultBlogPostsDto>().ReverseMap();
            CreateMap<CreateBlogPostsDto, BlogPosts>();
            CreateMap<UpdateBlogPostsDto, BlogPosts>();

            CreateMap<Testimonials, ResultTestimonialsDto>().ReverseMap();
            CreateMap<CreateTestimonialsDto, Testimonials>();
            CreateMap<UpdateTestimonialsDto, Testimonials>();


        }
    }
}
