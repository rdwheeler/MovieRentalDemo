﻿// <auto-generated />
using System;
using System.Reflection;
using Commerce.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using RentalService.AppCore.Core;

#pragma warning disable 219, 612, 618
#nullable enable

namespace RentalService.Infrastructure
{
    partial class RentalEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "RentalService.AppCore.Core.Rental",
                typeof(Rental),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(Guid),
                propertyInfo: typeof(EntityBase).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("Relational:ColumnType", "uuid");
            id.AddAnnotation("Relational:DefaultValueSql", "uuid_generate_v4()");

            var beginTime = runtimeEntityType.AddProperty(
                "BeginTime",
                typeof(DateTime),
                propertyInfo: typeof(Rental).GetProperty("BeginTime", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<BeginTime>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            beginTime.AddAnnotation("Relational:ColumnName", "begin_time");

            var created = runtimeEntityType.AddProperty(
                "Created",
                typeof(DateTime),
                propertyInfo: typeof(EntityBase).GetProperty("Created", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<Created>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd);
            created.AddAnnotation("Relational:ColumnName", "created");
            created.AddAnnotation("Relational:DefaultValueSql", "now()");

            var customerId = runtimeEntityType.AddProperty(
                "CustomerId",
                typeof(Guid),
                propertyInfo: typeof(Rental).GetProperty("CustomerId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<CustomerId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            customerId.AddAnnotation("Relational:ColumnName", "customer_id");
            customerId.AddAnnotation("Relational:ColumnType", "uuid");

            var endTime = runtimeEntityType.AddProperty(
                "EndTime",
                typeof(DateTime),
                propertyInfo: typeof(Rental).GetProperty("EndTime", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<EndTime>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            endTime.AddAnnotation("Relational:ColumnName", "end_time");

            var isReturned = runtimeEntityType.AddProperty(
                "IsReturned",
                typeof(bool),
                propertyInfo: typeof(Rental).GetProperty("IsReturned", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<IsReturned>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            isReturned.AddAnnotation("Relational:ColumnName", "is_returned");

            var productId = runtimeEntityType.AddProperty(
                "ProductId",
                typeof(Guid),
                propertyInfo: typeof(Rental).GetProperty("ProductId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<ProductId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            productId.AddAnnotation("Relational:ColumnName", "product_id");
            productId.AddAnnotation("Relational:ColumnType", "uuid");

            var rentalCost = runtimeEntityType.AddProperty(
                "RentalCost",
                typeof(decimal),
                propertyInfo: typeof(Rental).GetProperty("RentalCost", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<RentalCost>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            rentalCost.AddAnnotation("Relational:ColumnName", "rental_cost");

            var returnDueTime = runtimeEntityType.AddProperty(
                "ReturnDueTime",
                typeof(DateTime),
                propertyInfo: typeof(Rental).GetProperty("ReturnDueTime", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Rental).GetField("<ReturnDueTime>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            returnDueTime.AddAnnotation("Relational:ColumnName", "return_due_time");

            var updated = runtimeEntityType.AddProperty(
                "Updated",
                typeof(DateTime?),
                propertyInfo: typeof(EntityBase).GetProperty("Updated", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(EntityBase).GetField("<Updated>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            updated.AddAnnotation("Relational:ColumnName", "updated");

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);
            key.AddAnnotation("Relational:Name", "pk_rentals");

            var index = runtimeEntityType.AddIndex(
                new[] { id },
                unique: true);
            index.AddAnnotation("Relational:Name", "ix_rentals_id");

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", "prod");
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Rentals");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
