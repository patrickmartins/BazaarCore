using AutoMapper;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Models;
using System;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class QuestionToModel : Profile
    {
        public QuestionToModel()
        {
            CreateMap<Question, QuestionModel>();

            CreateMap<RegisterQuestionModel, Question>()
                .ConstructUsing(c => new Question(c.Id, c.Description, DateTime.UtcNow, c.IdAdvertiser, c.IdAd))
                .ForAllMembers(c => c.Ignore());
        }
    }
}
