// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore.ChangeTracking;
using PulseSql.EntityFrameworkCore.MySql.Storage.Internal;

namespace PulseSql.EntityFrameworkCore.MySql.Storage.ValueComparison.Internal
{
    public interface IMySqlJsonValueComparer
    {
        ValueComparer Clone(MySqlJsonChangeTrackingOptions options);
    }
}
