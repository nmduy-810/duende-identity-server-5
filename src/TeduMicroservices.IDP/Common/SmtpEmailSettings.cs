namespace TeduMicroservices.IDP.Common;

public class SmtpEmailSettings
{
    public string DisplayName { get; set; } = default!;
    
    public bool EnableVerification { get; set; }
    
    public string From { get; set; } = default!;
    
    public string SmtpServer { get; set; } = default!;
    
    public bool UseSsl { get; set; }
    
    public int Port { get; set; }
    
    public string Username { get; set; } = default!;
    
    public string Password { get; set; } = default!;
}