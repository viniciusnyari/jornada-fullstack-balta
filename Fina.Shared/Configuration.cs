﻿namespace Fina.Shared;

public static class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public const int DefaultStatusCodeSuccess = 200;
    public const int DefaultStatusCodeSuccessFullCreated = 201;
    public const int DefaultStatusCodeSuccessFinal = 299;
    public const int DefaultStatusCodeNotFound = 404;
    public const int DefaultStatusCodeInternalError = 500;

    public static string BackendUrl { get; set; } = "http://localhost:5250";
    public static string FrontendUrl { get; set; } = "http://localhost:5200";
}