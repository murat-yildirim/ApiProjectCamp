﻿using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Dtos.NotificationDtos;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectCamp.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap(); 
            CreateMap<Feature,CreateFeatureDto>().ReverseMap(); 
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap(); 
            CreateMap<Feature,GetByIdFeatureDto>().ReverseMap(); 

            CreateMap<Message,ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            //formember(her üye için anlamına geliyor)
            //formember(getirmek istediğimiz veri)
            //MapFrom(Name nereden getiricem onun yolu)
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();

        }
    }
}
