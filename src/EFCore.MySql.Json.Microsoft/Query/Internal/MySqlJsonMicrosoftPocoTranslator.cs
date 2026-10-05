using System.Reflection;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using PulseSql.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;
using PulseSql.EntityFrameworkCore.MySql.Query.Internal;

namespace PulseSql.EntityFrameworkCore.MySql.Json.Microsoft.Query.Internal
{
    public class MySqlJsonMicrosoftPocoTranslator : MySqlJsonPocoTranslator
    {
        public MySqlJsonMicrosoftPocoTranslator(
            [NotNull] IRelationalTypeMappingSource typeMappingSource,
            [NotNull] ISqlExpressionFactory sqlExpressionFactory)
        : base(typeMappingSource, (MySqlSqlExpressionFactory)sqlExpressionFactory)
        {
        }

        public override string GetJsonPropertyName(MemberInfo member)
            => member.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name;
    }
}
