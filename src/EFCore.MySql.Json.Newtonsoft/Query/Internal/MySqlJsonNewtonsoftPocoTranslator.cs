using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using PulseSql.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;
using PulseSql.EntityFrameworkCore.MySql.Query.Internal;

namespace PulseSql.EntityFrameworkCore.MySql.Json.Newtonsoft.Query.Internal
{
    public class MySqlJsonNewtonsoftPocoTranslator : MySqlJsonPocoTranslator
    {
        public MySqlJsonNewtonsoftPocoTranslator(
            [NotNull] IRelationalTypeMappingSource typeMappingSource,
            [NotNull] ISqlExpressionFactory sqlExpressionFactory)
        : base(typeMappingSource, (MySqlSqlExpressionFactory)sqlExpressionFactory)
        {
        }

        public override string GetJsonPropertyName(MemberInfo member)
            => member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;
    }
}
