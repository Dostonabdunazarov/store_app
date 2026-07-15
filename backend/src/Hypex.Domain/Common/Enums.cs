namespace Hypex.Domain.Common;

/// <summary>User roles for authorization.</summary>
public enum UserRole
{
    Customer = 0,
    Admin = 1,
}

/// <summary>Lifecycle of an order (pay-on-delivery, no online payment).</summary>
public enum OrderStatus
{
    Pending = 0,
    Confirmed = 1,
    Shipped = 2,
    Delivered = 3,
    Cancelled = 4,
}

/// <summary>Supported UI/content languages for translations.</summary>
public static class Languages
{
    public const string Ru = "ru";
    public const string Uz = "uz";
    public const string En = "en";

    public static readonly IReadOnlyList<string> All = new[] { Ru, Uz, En };

    public static bool IsSupported(string? lang) =>
        lang is not null && All.Contains(lang);
}
