﻿namespace CleanMethodology.Application.Contracts.Entities.Emails;

public class EmailMessage
{
    public string ToEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
