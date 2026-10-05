// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PulseSql.EntityFrameworkCore.MySql.Infrastructure.Internal;
using PulseSql.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;
using PulseSql.EntityFrameworkCore.MySql.Storage.Internal;

namespace PulseSql.EntityFrameworkCore.MySql.Query.Internal
{
    public class MySqlMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
    {
        public MySqlMethodCallTranslatorProvider(
            [NotNull] RelationalMethodCallTranslatorProviderDependencies dependencies,
            [NotNull] IMySqlOptions options)
            : base(dependencies)
        {
            var sqlExpressionFactory = (MySqlSqlExpressionFactory)dependencies.SqlExpressionFactory;
            var relationalTypeMappingSource = (MySqlTypeMappingSource)dependencies.RelationalTypeMappingSource;

            AddTranslators(new IMethodCallTranslator[]
            {
                new MySqlByteArrayMethodTranslator(sqlExpressionFactory),
                new MySqlConvertTranslator(sqlExpressionFactory),
                new MySqlDateTimeMethodTranslator(sqlExpressionFactory),
                new MySqlDateDiffFunctionsTranslator(sqlExpressionFactory),
                new MySqlDbFunctionsExtensionsMethodTranslator(sqlExpressionFactory),
                new MySqlJsonDbFunctionsTranslator(sqlExpressionFactory),
                new MySqlMathMethodTranslator(sqlExpressionFactory),
                new MySqlNewGuidTranslator(sqlExpressionFactory),
                new MySqlObjectToStringTranslator(sqlExpressionFactory),
                new MySqlRegexIsMatchTranslator(sqlExpressionFactory),
                new MySqlStringComparisonMethodTranslator(sqlExpressionFactory, () => QueryCompilationContext, options),
                new MySqlStringMethodTranslator(sqlExpressionFactory, relationalTypeMappingSource, () => QueryCompilationContext, options),
            });
        }

        public virtual QueryCompilationContext QueryCompilationContext { get; set; }

        public override SqlExpression Translate(
            IModel model,
            SqlExpression instance,
            MethodInfo method,
            IReadOnlyList<SqlExpression> arguments,
            IDiagnosticsLogger<DbLoggerCategory.Query> logger)
            => QueryCompilationContext is not null
                ? base.Translate(model, instance, method, arguments, logger)
                : throw new InvalidOperationException();
    }
}
