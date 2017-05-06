using AutoMapper;
using Dorado.Objects;
using System.Collections.Generic;

namespace Dorado.Data.Mapping
{
    public class ObjectMapper
    {
        public static void MapObjects()
        {
            Mapper.Initialize(configuration => new ObjectMapper(configuration).Map());
        }

        private IMapperConfigurationExpression Configuration { get; }

        private ObjectMapper(IMapperConfigurationExpression configuration)
        {
            Configuration = configuration;
            Configuration.AddConditionalObjectMapper()
                .Conventions.Add(pair => pair.SourceType.Namespace != "System.Data.Entity.DynamicProxies");
        }

        private void Map()
        {
            MapRoles();
        }

        #region Administration

        private void MapRoles()
        {
            Configuration.CreateMap<Role, RoleView>()
                .ForMember(role => role.Permissions, member => member.Ignore());
            Configuration.CreateMap<RoleView, Role>()
                .ForMember(role => role.Permissions, member => member.UseValue(new List<RolePermission>()));
        }

        #endregion Administration
    }
}