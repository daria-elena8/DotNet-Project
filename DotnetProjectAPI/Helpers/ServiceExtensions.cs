using DotnetProjectAPI.Repositories.UserRepository;
using DotnetProjectAPI.Repositories.VisitRepository;
using DotnetProjectAPI.Repositories.PlaceRepo;
using DotnetProjectAPI.Repositories.GenericRepository;
using DotnetProjectAPI.Repositories.LikeRepository;
using DotnetProjectAPI.Repositories.CommentRepository;
using DotnetProjectAPI.Repositories.PlaceRatingRepository;
using DotnetProjectAPI.Services.UserService;
using DotnetProjectAPI.Services.VisitService;
using DotnetProjectAPI.Services.PlaceService;
using DotnetProjectAPI.Services.GenericService;
using DotnetProjectAPI.Services.LikeService;
using DotnetProjectAPI.Services.CommentService;
using DotnetProjectAPI.Services.RatingService;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetProjectAPI.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IPlaceRepo, PlaceRepo>();
            services.AddScoped<ILikeRepository, LikeRepository>(); 
            services.AddScoped<ICommentRepository, CommentRepository>(); 
            services.AddScoped<IPlaceRatingRepository, PlaceRatingRepository>(); 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ICommentService, CommentService>(); 
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            return services;
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
            return services;
        }
    }
}
