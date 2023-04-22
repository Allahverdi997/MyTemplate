using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Service.Other;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.Enum;
using Application.Exception.Main;
using Application.Factory;
using Application.Static.Message;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Other
{
    public class FilterService : IFilterService
    {
        private readonly IAppSession AppSession;
        private readonly IUnitOfWork UnitOfWork;
        //private readonly IMapper _mapper;
        private readonly IAppSetting AppSetting;

        public FilterService(
            IAppSession appSession,
            IUnitOfWork unitOfWork,
            //IMapper mapper,
            IAppSetting appSettings)
        {
            AppSession = appSession;
            UnitOfWork = unitOfWork;
            //_mapper = mapper;
            AppSetting = appSettings;
        }

        void IFilterService.AuthenticateUser(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedException(ExceptionEnum.UnauthorizedException.ToString(),null,true);

            var handler = new JwtSecurityTokenHandler();
            var tokenIngredient = handler.ReadJwtToken(token) as JwtSecurityToken;
            var claims = tokenIngredient.Claims.ToList();
            if (claims[0].Value != AppSetting.SqlConnectionString)
                throw new UnauthorizedException(ExceptionEnum.UnauthorizedException.ToString(), null, true);
        }

        void IFilterService.AddLanguage(string? lang)
        {
            int langId = 1;
            if (UnitOfWork.LanguageReadRepository.CheckExist(l => l.Shortname == lang))
                langId = UnitOfWork.LanguageReadRepository.GetSingle(l => l.Shortname == lang).Id;

            AppSession.LangId = langId;
        }
    }
}
